    key2 = "1";
    if(!map.TryGetValue(key1, out var subMap))
    {
      map[key1] = subMap = new Dictionary<string, int>();
    }
    subMap[key2] = 54;
    key2 = "b";
    if(!map.TryGetValue(key1, out var subMap))
    {
      map[key1] = subMap = new Dictionary<string, int>();
    }
    subMap[key2] = 47;
