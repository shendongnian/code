    IEnumerable<int> GetDuplicates(IDictionary<int, List<int>> dict, IEnumerable<int> keysToLook)
    {
        return dict.Keys
            .Intersect(keysToLook)
            .SelectMany(k => dict[k])
            .GroupBy(i => i)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToArray();
    }
