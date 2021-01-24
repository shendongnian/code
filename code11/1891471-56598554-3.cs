    private static bool SequenceUnorderedEqual<T>(IEnumerable<T> source1,
        IEnumerable<T> source2)
    {
        var occurences = new Dictionary<T, int>();
        // Populating the dictionary using source1
        foreach (var item in source1)
        {
            int value;
            if (!occurences.TryGetValue(item, out value))
            {
                value = 0;
            }
            occurences[item] = value + 1;
        }
        // Depopulating the dictionary using source2
        foreach (var item in source2)
        {
            int value;
            if (!occurences.TryGetValue(item, out value))
            {
                value = 0;
            }
            if (value <= 0) return false;
            occurences[item] = value - 1;
        }
        // Now all counters should be reduced to zero
        return occurences.Values.All(c => c == 0);
    }
