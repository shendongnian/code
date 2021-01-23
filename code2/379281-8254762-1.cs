    static IEnumerable<DateTime> GetRange(DateTime start, DateTime end)
    {
        for (DateTime current = start; current <= end; current = current.AddDays(1))
        {
            yield return current;
        }
    }
