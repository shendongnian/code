    private static IEnumerable<string> GetTopWords(int Count)
    {
        var popularWords = (from w in words                
              group w by w
              into grp
              orderby grp.Count() descending
              select grp.Key).Take(Count).ToList();
        return popularWords;
    }
