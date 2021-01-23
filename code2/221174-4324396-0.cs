    var keys = ActiveDictionary
        .Where(kv => kv.Value.Ready)
        .Select(kv => kv.Key).ToList();
    keys.ForEach(k =>
            {
                ProcessedDictionary.Add(k, ActiveDictionary[k]);
                ActiveDictionary.Remove(k);
            });
