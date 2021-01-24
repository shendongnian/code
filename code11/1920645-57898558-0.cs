    public static List<DateTime> GetRange(DateTime start, DateTime end, TimeSpan interval)
    {
        var result = new List<DateTime>();
        while ((start = start.Add(interval)) < end) result.Add(start);
        return result;
    }
