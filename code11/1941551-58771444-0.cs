    public static double GetWeekendDaysCount(DateTime startDate, DateTime endDate)
    {
        if (startDate == endDate) return 0;
        if (startDate > endDate)
        {
            DateTime temp = startDate;
            startDate = endDate;
            endDate = temp;
        }
        double weekendDays = 0;
        var current = startDate;
        while (current <= endDate)
        {
            if (current.DayOfWeek == DayOfWeek.Saturday || 
                current.DayOfWeek == DayOfWeek.Sunday)
            {
                // If the time is midnight, count it as one day,
                // otherwise add a fraction of a day
                weekendDays += current.TimeOfDay > TimeSpan.Zero
                    ? current.TimeOfDay.TotalHours / 24
                    : 1;
            }
            // Add a day and set the time to midnight by using 'Date'
            current = current.AddDays(1).Date;
                // Unless we're on the last day, then we want 
                // to use the TimeOfDay that was specified
            if (current == endDate.Date) current = endDate;
        }
        return weekendDays;
    }
