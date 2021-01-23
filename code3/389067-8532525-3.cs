    IList<string> results = new List<string>();
    foreach (var key in map1.Keys)
    {
        if (map2.ContainsKey(key))
        {
            results.Add(map1[key] + " / " + map2[key]);
        }
    }
    OUTPUT:
    M1-A / M2-A
    M1-B / M2-B
