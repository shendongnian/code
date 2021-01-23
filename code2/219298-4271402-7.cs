    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source,
                                               List<Pair<int, int>> ranges)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        // If ranges is null, just return the source. From spec.
        return ranges == null ? source : RangeIterate(source, ranges);
    }
    
    private static IEnumerable<T> RangeIterate<T>(IEnumerable<T> source, 
                                                  List<Pair<int, int>> ranges)
    {
        // The key bit: a lazy sequence of all valid indices belonging to
        // each range. No buffering.
        var validIndices = from range in ranges
                           let start = Math.Max(0, range.First)
                           from validIndex in Enumerable.Range(start, range.Second - start + 1)
                           select validIndex;
        int currentIndex = -1;
    
        using (var indexErator = validIndices.GetEnumerator())
        {
            // Optimization: Get out early if there are no ranges.
            if (!indexErator.MoveNext())
                yield break;
    
            foreach (var item in source)
            {
                if (++currentIndex == indexErator.Current)
                {
                   // Valid index, yield.
                    yield return item;
    
                    // Move to the next valid index.
                    // Optimization: get out early if there aren't any more.
                    if (!indexErator.MoveNext())
                        yield break;
                }
            }
        }
    }
