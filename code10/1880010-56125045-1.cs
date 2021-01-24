    public static List<DateTime> FilterDatesBetween(List<DateTime> dates, 
    DateTime start, DateTime end)
    {
        return dates.Where(date => IsDateInPeriod(date, start, end)).
                            OrderBy(date => date).ToList();
    }
    public static bool IsDateInPeriod(DateTime date, DateTime start, DateTime end)
    {
        return (date > start && date < end);
    }
