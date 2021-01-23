    string lineRead;
    string current;
    var dictionary = new Dictionary<string, List<string>>);
    while((lineRead = reader.ReadLine())
    {
        if(!lineRead.StartsWith("  "))
        {
            dictionary.Add(lineRead, new List<string>());
            current = lineRead;
        }
        else
        {
            dictionary[current].Add(lineRead);
        }
    }
    dictionary.Keys.ToList().ForEach(y => dictionary[y] = dictionary[y].OrderBy(x => x).ToList());
    dictionary.OrderBy(y => y.Key);
