    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source,
                                               List<Pair<int, int>> ranges)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        return ranges == null ? source : RangeIterate(source, ranges);
    }
    
    private static IEnumerable<T> RangeIterate<T>(IEnumerable<T> source, 
                                                  List<Pair<int, int>> ranges)
    {
        // the key bit: a lazy sequence of all valid indices belonging to
        // each range. No buffering.
        var validIndices = ranges
                          .SelectMany(range => Enumerable.Range
                              (range.First, range.Second - range.First + 1));
        int currentIndex = -1;
    
        using (var indexErator = validIndices.GetEnumerator())
        {
            // get out if there are no ranges
            if (!indexErator.MoveNext())
                yield break;
    
            foreach (var item in source)
            {
                if (++currentIndex == erator.Current)
                {
                    yield return item;
    
                    if (!indexErator.MoveNext())
                        yield break;
                }
            }
        }
    }
