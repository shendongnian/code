    public static DateTime DayStart(DateTime date)
    {
        return date.Date.AddHours(7);
    }
    public static DateTime DayEnd(DateTime date)
    {
        return date.Date.AddHours(14);
    }
    public static TimeSpan DiffSingleDay(DateTime start, DateTime end)
    {
        if ( start.Date != end.Date ) {
            throw new ArgumentException();
        }
        if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday )
        {
            return TimeSpan.Zero;
        }
        start = start >= DayStart(start) ? start : DayStart(start);
        end = end <= DayEnd(end) ? end : DayEnd(end);
        return end - start;
    }
    public static TimeSpan DiffRange(DateTime start, DateTime end)
    {
        if (start.Date == end.Date)
        {
            return DiffSingleDay(start, end);
        }
        var firstDay = DiffSingleDay(start, DayEnd(start));
        var lastDay = DiffSingleDay(DayStart(end), end);
        var middle = TimeSpan.Zero;
        var current = start.AddDays(1);
        while (current.Date != end.Date)
        {
            middle = middle + DiffSingleDay(current.Date, DayEnd(current.Date));
            current = current.AddDays(1);
        }
        return firstDay + lastDay + middle;
    }
