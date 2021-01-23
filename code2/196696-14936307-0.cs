    public static IEnumerable<List<T>> SplitAt<T>(this IEnumerable<T> source, 
                                                  Func<T, bool> separatorPredicate,
                                                  bool includeEmptyEntries = false, 
                                                  bool includeSeparators = false)
    {
        var l = new List<T>();
        foreach (var x in source)
        {
            if (!separatorPredicate(x))
                l.Add(x);
            else
            {
                if (includeEmptyEntries || l.Count != 0)
                {
                    if (includeSeparators)
                        l.Add(x);
                    yield return l;
                }
                l = new List<T>();
            }
        }
    }
