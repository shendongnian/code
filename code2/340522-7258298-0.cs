    string[] lines= File.ReadAllLines(filePath);
    Dictionary<string, string> items;
                    
    foreach (var line in lines )
    {
        var key = line.Split('|').ElementAt(0);
        if (!items.ContainsKey(key))
            items.Add(key, line);
    }
    List<string> list_lines = items.Values.ToList();
