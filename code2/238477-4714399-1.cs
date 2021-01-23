    var newDictionary = new SortedDictionary<int, int>();
    int runningTotal = 0;
    foreach (var pair in lengthDictionary)
    {
        runningTotal += pair.Value;
        newDictionary.Add(pair.Key, runningTotal);
    }
