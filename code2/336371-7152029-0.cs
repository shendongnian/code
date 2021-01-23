    List<string> removals = new List<string>();
    
    foreach (string s in theFinalList)
    {
        //do stuff with (s);
        removals.Add(s);
    }
    
    foreach (string s in removals)
    {
        theFinalList.Remove(s);
    }
