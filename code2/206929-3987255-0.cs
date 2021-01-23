    List<string> keys = ...;    // load all strings
    foreach(string f in Files)
    {
        //search for each string that is not already found
        string text = System.IO.File.ReadAllText(f);  //easy version of ReadToEnd
        // brute force
        foreach(string key in keyes)
        {
            if (text.IndexOf(key) >= 0) ....
        }
    }
