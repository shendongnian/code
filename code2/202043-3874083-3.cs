    static IEnumerable<int> GetDeltas(IEnumerable<int> collection)
    {
        int? previous = null;
        foreach (int value in collection)
        { 
            if (previous != null)
            {
                yield return value - (int)previous;
            }
            previous = value;
        }
    }
