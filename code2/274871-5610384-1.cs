    var toRemove = dictionary.Where(pair => pair.Value < 0)
                             .Select(pair => pair.Key)
                             .ToList();
    foreach (var key in toRemove)
    {
        dictionary.Remove(key);
    }
