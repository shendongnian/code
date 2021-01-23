    Dictionary<string, string> map = new Dictionary<string, string>();
    foreach (string line in ReadLines(path))
    {
        map[line] = line;
    }
    List<string> intersection = new List<string>();
    foreach (string line in ReadLines(path2))
    {
        if (map.ContainsKey(line))
        {
            intersection.Add(line);
        }
    }
