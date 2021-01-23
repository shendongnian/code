    foreach (KeyValuePair<string, List<int>> entry in Origins)
    {
        List<int> originsValues = entry.Value;
        List<int> changesValues;
        // handle no key in Changes (as pointed out by Guillaume V). 
        if (!Changes.TryGet(entry.Key, out changesValues)) changesValues = originsValues;
        IEnumerable<int> removedValues = originsValues.Except(changesValues);
        IEnumerable<int> addedValues = changesValues.Except(originsValues);
        // your processing here
    }
