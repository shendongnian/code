    public static DateTime? GetNthWeekDayInMonth(DateTime month, int nth, List<DayOfWeek> weekdays)
    {
        var multiplier = (nth < 0 ? -1 : 1);
        var day = new DateTime(month.Year, month.Month, 1);
        // If we're looking backwards, start at end of month
        if (multiplier == -1) day = day.AddMonths(1).AddDays(-1);
        var dayCount = weekdays.Count;
        if (dayCount == 0)
            return null;
        // Fast forward (or rewind) a few days to appropriate week
        var weeks = ((nth - (1 * multiplier)) / dayCount);
        day = day.AddDays(weeks * 7);
        // Current Nth value
        var currentNth = (1 * multiplier) + (weeks * dayCount);
        // Loop through next week looking for Nth value
        for (var x = 0; x <= 7; x++)
        {
            if (weekdays.Contains(day.DayOfWeek))
            {
                if (currentNth == nth)
                {
                    // Verify the nth instance is still in the current month
                    if (day.Month == month.Month)
                        return day;
                    else
                        return null;
                }
                currentNth += multiplier;
            }
            day = day.AddDays(multiplier);
        }
        return null;
    }
