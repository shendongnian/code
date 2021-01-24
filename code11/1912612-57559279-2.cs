    Dictionary<string, string> keys = new Dictionary<string,string>();
    foreach(string line in File.ReadLines("yourInputFile.csv"))
    {
        var splittedLine = line.Split(',');
        if(!keys.ContainsKey(splittedLine[0])
            keys.Add(splittedLine[0], line);
            // or, if you want only the second element
            //keys.Add(splittedLine[0], splittedLine[1]);
    }
