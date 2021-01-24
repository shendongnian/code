    public static int CalculateWeekendMinutes(DateTime start, DateTime end)
    {
        int weekendMinutes = 0;
        // First and last day will be handled seperately in the end
        var firstFullDay = start.AddDays(1).Date;
        var lastFullDay = end.AddDays(-1).Date;
        TimeSpan limitedSpan = lastFullDay - firstFullDay;
        int spanLengthDays = (int)limitedSpan.TotalDays;
        var dateIterator = firstFullDay;
        // Looping over the limited span allows us to analyse all the full days
        while (dateIterator <= lastFullDay)
        {
            weekendMinutes += (24*60);
            dateIterator = dateIterator.AddDays(1);
        }
        // Finally we can calculate the partial days and add that to our total
        weekendMinutes += CalculateMinutesOnFirstDay(start);
        weekendMinutes += CalculateMinutesOnLastDay(end);
        return weekendMinutes;
    }
    // Helps us calculate the minutes of the first day in the span
    private static int CalculateMinutesOnFirstDay(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            // We want to know how many minutes there are UNTIL the next midnight
            int minutes = (int)(date.Date.AddDays(1) - date).TotalMinutes;
            return minutes;
        }
        else
        {
            return 0;
        }
    }
 
    // Helps us calculate the minutes of the last day in the span
    private static int CalculateMinutesOnLastDay(DateTime date)
    {
        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
        {
            // We want to know how many minutes there are SINCE the last midnight
            int minutes = (int)(date - date.Date).TotalMinutes;
            return minutes;
        }
        else
        {
            return 0;
        }
    }
