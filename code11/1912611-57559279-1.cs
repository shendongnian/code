    Dictionary<string, string> keys = new Dictionary<string,string>();
    foreach(string line in File.ReadLines("yourInputFile.csv"))
    {
        if(!keys.ContainsKey(line.Split(',')[0]))
            keys.Add(line.Split(',')[0], line);
            // or, if you want only the second element
            //keys.Add(line.Split(',')[0], line.Split(',')[1]);
    }
