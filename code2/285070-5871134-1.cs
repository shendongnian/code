    var cachedDictionary = new Dictionary<int, YourType>();
    foreach (var item in searchItemsCached)
    {
      cachedDictionary.Add(item.ID, item);
    }
    foreach (var item in searchItemsNonCached)
    {
      YourType match;
      if (cachedDictionary.TryGetValue(out match))
      {
        item.Description = match.Description;
      }
    }
