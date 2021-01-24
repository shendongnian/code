    public static IEnumerable<List<TimeSpan>> GroupItemsWithin(IEnumerable<TimeSpan> times, TimeSpan maxDelta)
    {
        var previous = TimeSpan.MinValue;
        var spans    = new List<TimeSpan>();
        foreach (var span in times)
        {
            if (previous == TimeSpan.MinValue || (span - previous) <= maxDelta)
            {
                spans.Add(span);
            }
            else if (spans.Count > 0)
            {
                yield return spans;
                spans = new List<TimeSpan>{ span };
            }
            previous = span;
        }
        if (spans.Count > 0)
            yield return spans;
    }
