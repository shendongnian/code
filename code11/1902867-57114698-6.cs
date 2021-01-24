    public static IEnumerable<Range<DateTime>> SplitDateRange(DateTime start, DateTime end, TimeSpan ChunkSize)
    {
        DateTime chunkEnd;
        while ((chunkEnd = start.Add(ChunkSize)) < end)
        {
            yield return new Range<DateTime>(start, chunkEnd);
            start = chunkEnd;
        }
        yield return new Range<DateTime>(start, end);
    }
    
