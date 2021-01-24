    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Web.UI.WebControls;
    using System.Linq;
    //list to hold the keys
    List<string> keys = new List<string>();
    
    //dummy data
    keys = Enumerable.Range(1, 20).Select(i => "Key_" + i).ToList();
    
    //or read the file from disk
    string path = Server.MapPath("keys.txt");
    if (File.Exists(path))
    {
        keys = File.ReadAllLines(path).ToList();
    }
    
    //create a random number and select the key
    Random rnd = new Random();
    string key = keys[rnd.Next(0, keys.Count)];
