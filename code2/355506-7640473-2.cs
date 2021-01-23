    public HashSet<string> FindShortestSubString(HashSet<string> set)
    {
        var comparer = new ShortestSubStringComparer();
        return new HashSet<string>(set.GroupBy(e => e, comparer).Select(g => g.Min(e => e)));
    }
    
