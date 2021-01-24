    IEnumerable<int> GetDuplicates(IDictionary<int, IEnumerable<int>> dict, IEnumerable<int> keysToLook)
    {
        return dict.Keys
            .Intersect(keysToLook)
            .Select(k => dict[k])
            .Aggregate((p, n) => p.Intersect(n));
    }
