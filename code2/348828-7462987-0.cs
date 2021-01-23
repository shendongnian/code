    public static uint[] RemoveRange(this uint[] source_array, uint[] entries_to_remove)
    {
        var referenceCount = new Dictionary<uint, int>();
        foreach (uint n in source_array)
        {
            if (!referenceCount.ContainsKey(n))
                referenceCount[n] = 1;
            else
                referenceCount[n]++;
        }
        foreach (uint n in entries_to_remove)
        {
            if (referenceCount.ContainsKey(n))
                referenceCount[n]--;
        }
        return referenceCount.Where(x => x.Value > 0)
                             .Select(x => Enumerable.Repeat(x.Key, x.Value))
                             .SelectMany( x => x)
                             .ToArray();
    }
