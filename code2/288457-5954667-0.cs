    string longStr = "School||Abc\r\nState||CA\r\n";
    string[] keyValPairs = s.Split("\r\n".ToCharArray());
    Dictionary<string, string> info = new Dictionary<string, string>();
    
    foreach(string pair in keyValPairs)
    {
       string[] split = pair.Split("||");
        //split[0] is the key, split[1] is the value
       info.Add(split[0], split[1]);
    }
