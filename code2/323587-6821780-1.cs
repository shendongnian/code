    string returnStr = "Claus,Junker,Jørgensen";
    string[] keys = new string[]
    {
        "FirstName",
        "MiddleName",
        "LastName"
    };
    
    Dictionary<string, string> groups = returnStr.Split(',')
             .Select((x, i) => Tuple.Create(keys[i], x))
             .ToDictionary(k => k.Item1, v => v.Item2);
    // Alternative version
    Dictionary<string, string> groups = returnStr.Split(',')
             .Zip(keys, (k, v) => new KeyValuePair<string, string>(k, v))
             .ToDictionary(k => k.Key, v => v.Value);
