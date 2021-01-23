    static IEnumerable<DateTime> DaysInRangeUntil(this DateTime start, DateTime end)
    {
        return Enumerable.Range(0, 1 + (int)Math.Ceiling((end - start).TotalDays))
                         .Select(dt => start.Date.AddDays(dt));
    }
    static bool IsWeekendDay(this DateTime dt)
    {
        return dt.DayOfWeek == DayOfWeek.Saturday
            || dt.DayOfWeek == DayOfWeek.Sunday;
    }
    static DateTime Max(DateTime a, DateTime b)
    {
        return new DateTime(Math.Max(a.Ticks, b.Ticks));
    }
    static DateTime Min(DateTime a, DateTime b)
    {
        return new DateTime(Math.Min(a.Ticks, b.Ticks));
    }
