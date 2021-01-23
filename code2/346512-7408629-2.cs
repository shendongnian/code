    foreach (KeyValuePair<string, List<int>> entry in Origins)
    {
        List<int> originsValues = entry.Value;
        List<int> changesValues = Changes[entry.Key].Value;
        IEnumerable<int> removedValues = originsValues.Except(changesValues);
        IEnumerable<int> addedValues = changesValues.Except(originsValues);
        // your processing here
    }
