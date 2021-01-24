    public static List<DateTime> GetRange(DateTime start, DateTime end, TimeSpan interval)
    {
        // Set the initial size of the list to avoid dynamic resizing during 'Add' operations
        int itemCount = (int)Math.Ceiling((double)(end2-start).Ticks / interval.Ticks + 2);
        var result = new List<DateTime>(itemCount);
        while ((start = start.Add(interval)) < end) result.Add(start);
        return result;
    }
