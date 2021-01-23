    Dictionary<string, string> addresses = new Dictionary<string, string>();
    foreach(string result in resultsArray)
    {
        string splitResult[] = result.Split('|');
        // check to see if address already exists, if it does, skip it.
        if(!addresses.ContainsKey(splitResult[1]))
        {
            addresses.add(splitResult[1], splitResult[0]);
        }
    }   
