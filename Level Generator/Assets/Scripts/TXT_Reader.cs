using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class TXT_Reader : MonoBehaviour
{

    public TextAsset file;
    
    private char[] chararray;
    private string[] stringarray;

    [SerializeField]
    private int Hight;
    [SerializeField]
    private int width;
    [SerializeField]
    private string filetxt;
    
    public Vector3 spawnpoint;
    

    // Use this for initialization
    void Start()
    {
        //temp variables
        string templine1;
        string fileName;
        string[] tempstrarray;
        //make string
        filetxt = file.ToString();
        // split at the first line
        tempstrarray = filetxt.Split('*');
        templine1 = tempstrarray[0];
        //remove the first line and make char array
        filetxt = tempstrarray[1];
        filetxt.Replace(' ', ',');
        chararray = filetxt.ToCharArray();
        stringarray = filetxt.Split(',');
        //split line 1
        tempstrarray = templine1.Split(',');
        // set width and height
        int.TryParse(tempstrarray[0], out width);
        int.TryParse(tempstrarray[1], out Hight);
        fileName = tempstrarray[2];
        spawnpoint.y += Hight;
        makemap();
    }

    public void makemap()
    {
        float tempint=0;
        foreach(string i in stringarray)
        {
            MakeMapStrip(i,tempint);
            tempint+=1.6f;
        }

    }

   public void MakeMapStrip(string strip,float row)
    {
        int TmpInt=0;
        Vector3 tempspawn = spawnpoint;
        tempspawn.x += row;
        char[] TmpCharArray;
        TmpCharArray = strip.ToCharArray();
        foreach(char i in TmpCharArray)
        {
            
            if(i=='0')
            {
                Debug.Log("spawned nothing at");
                Debug.Log(tempspawn);
            }
            else if(i=='1')
            {
                Instantiate(Resources.Load("Block"),tempspawn,new Quaternion(0,0,0,0),this.transform);
                Debug.Log("spawned something at");
                Debug.Log(tempspawn);
            }
            //tempspawn.x -= 1;
            tempspawn.y -= 1.6f;
            TmpInt++;
        }
    }


}
