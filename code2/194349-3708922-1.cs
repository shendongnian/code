    int GetRegularWorkingDays(DateTime start, DateTime end)
    {
        return (
            from day in Range(start, end)
            where day.DayOfWeek != DayOfWeek.Saturday
            where day.DayOfWeek != DayOfWeek.Sunday
            select day).Count();
    }
    IEnumerable<DateTime> Range(DateTime start, DateTime end)
    {
        while (start <= end)
        {
            yield return start;
            start = start.AddDays(1);
        }
    }
