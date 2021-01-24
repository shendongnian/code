    // Sample String POS0001:615155172
    static IEnumerable<string> FindMissing(IEnumerable<string> masterList, ICollection<string> missingList) {
        var missingSet = new Dictionary<long, bool>(missingList.Count);
        foreach (string s in missingList)
            missingSet.Add(long.Parse("1" + s.Substring(3, 4) + s.Substring(8)), true);
        foreach (string s in masterList) {
            var key = long.Parse($"1{s.Substring(3, 4)}{s.Substring(8)}");
            if (!missingSet.ContainsKey(key))
                yield return s;
        }
    }
    static IEnumerable<string> FindMissingLinq(IEnumerable<string> masterList, ICollection<string> missingList) {
        var missingSet = missingList.ToDictionary(s => long.Parse("1" + s.Substring(3, 4) + s.Substring(8)), s => true);
        return masterList.Where(s => !missingSet.ContainsKey(long.Parse($"1{s.Substring(3, 4)}{s.Substring(8)}")));
    }
