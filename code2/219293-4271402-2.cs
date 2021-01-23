    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source, List<Pair<int, int>> ranges)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        if (ranges == null)
            return source;
    
        if (!range.Any())
            return Enumerable.Empty<T>();
    
        var validIndices = ranges
                          .SelectMany(range => Enumerable.Range
                            (range.First, range.Second - range.First + 1));
    
        // buffer the valid indices into a set
        var validIndicesSet = new HashSet<int>(validIndices);
    
        //optimization: don't take an index beyond the last index of the last range.
        return source.Take(ranges.Last().Second + 1)
                     .Where((item, index) => validIndicesSet.Contains(index));
    
    }
