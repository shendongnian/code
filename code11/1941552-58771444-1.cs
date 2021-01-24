    public static double GetWeekendDaysCount(DateTime start, DateTime end)
    {
        if (start == end) return 0;
        if (start > end)
        {
            DateTime temp = start;
            start = end;
            end = temp;
        }
        double weekendDays = 0;
        var current = start;
        // To be super accurate, we can calculate based on Ticks instead of hours
        var ticksInADay = (double)TimeSpan.FromDays(1).Ticks;
        while (current <= end)
        {
            if (current.DayOfWeek == DayOfWeek.Saturday || 
                current.DayOfWeek == DayOfWeek.Sunday)
            {
                // If the time is midnight, count it as one day,
                // otherwise add a fraction of a day
                weekendDays += current.TimeOfDay > TimeSpan.Zero
                    ? current.TimeOfDay.Ticks / ticksInADay
                    : 1;
            }
            // Add a day and set the time to midnight by using 'Date'
            current = current.AddDays(1).Date;
                // Unless we're on the last day, then we want 
                // to use the TimeOfDay that was specified
            if (current == end.Date) current = end;
        }
        return weekendDays;
    }
