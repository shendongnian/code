    key1 = "1";
    key2 = "a";
    if(!map.TryGetValue(key1, out var subMap))
    {
      map[key1] = subMap = new Dictionary<string, int>();
    }
    subMap[key2] = 54;
    // somewhere else in code
    key1 = "1";
    key2 = "b";
    if(!map.TryGetValue(key1, out var subMap))
    {
      map[key1] = subMap = new Dictionary<string, int>();
    }
    subMap[key2] = 47;
