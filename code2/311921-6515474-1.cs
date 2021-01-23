    List<string> keysToChange = new List<string>();
    foreach(KeyValuePair<string, string> entry in myDict)
    {
        if(...) // some check to see if it's an item you want to act on
        {
            keysToChange.Add(entry.Key);
        }
    }
    
    foreach(string key in keysToChange)
    {
       myDict[key] = "new value";
    
       // or "rename" a key
       myDict["new key"] = myDict[key];
       myDict.Remove(key);
    }
