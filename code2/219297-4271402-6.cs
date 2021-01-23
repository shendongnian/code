    public static IEnumerable<T> WalkRanges<T>(IEnumerable<T> source, List<Pair<int, int>> ranges)
    {
        if (source == null)
            throw new ArgumentNullException("source");
    
        if (ranges == null)
            return source;
    
        if (!range.Any())
            return Enumerable.Empty<T>();
    
        var validIndices = from range in ranges
                           let start = Math.Max(0, range.First)
                           from validIndex in Enumerable.Range(start, range.Second - start + 1)
                           select validIndex;
    
        // Buffer the valid indices into a set.
        var validIndicesSet = new HashSet<int>(validIndices);
    
        // Optimization: don't take an index beyond the last index of the last range.
        return source.Take(ranges.Last().Second + 1)
                     .Where((item, index) => validIndicesSet.Contains(index));
    
    }
