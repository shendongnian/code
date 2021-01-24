    Dictionary<string, string> keys = new Dictionary<string,string>();
    foreach(string line in File.ReadLines("yourInputFile.csv"))
    {
        if(!keys.ContainsKey(line.Split(',')[0])
            keys.Add(line.Split(',')[0], line);
    }
