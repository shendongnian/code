    Dictionary<string,List<string>> unDupe = new Dictionary<string, List<string>>();
    for (int i = 0; i < yourArray.Length; i++)
    {
        string[] split = yourArray[i].Split('|');
        if (unDupe.ContainsKey(split[0]))
        {
            unDupe[split[0]].Add(split[1]);
        }
        else
        {
            unDupe.Add(split[0], new List<string>() { split[1] });
        }
    }
    List<string> undupinated = new List<string>();
    foreach (var keyValuePair in unDupe)
    {
        undupinated.Add(string.Concat(keyValuePair.Key, "|", string.Join("~", keyValuePair.Value)));
    }
