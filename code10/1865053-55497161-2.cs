    // Sample String POS0001:615155172
    static long GetKey(string s) => long.Parse("1" + s.Substring(3, 4) + s.Substring(8));
    static IEnumerable<string> FindMissing(IEnumerable<string> masterList, ICollection<string> missingList) {
        var missingSet = new Dictionary<long, bool>(missingList.Count);
        foreach (string s in missingList)
            missingSet.Add(GetKey(s), true);
        // Compact LINQ Way, but potentially, ineffecient
        //var missingSet = missingList.ToDictionary(GetKey, s => true);
        return masterList.Where(s => !missingSet.ContainsKey(GetKey(s)));
    }
