    public static DateTime? GetNthWeekDayInMonth(DateTime month, int nth, List<DayOfWeek> weekdays)
    {
        var isReverse = (nth < 0);
        var day = new DateTime(month.Year, month.Month, 1);
        // If we're looking backwards, start at end of month
        if (isReverse)
        {
            day = day.AddMonths(1).AddDays(-1);
            nth = Math.Abs(nth);
        }
        var dayCount = weekdays.Count;
        if (dayCount == 0)
            return null;
        // Fast forward (or rewind) a few days to appropriate week
        var z = (nth / dayCount);
        day = day.AddDays(z * 7 * (isReverse ? -1 : 1));
        var x = 1 + (z * dayCount);
        while (x <= nth)
        {
            if (weekdays.Contains(day.DayOfWeek))
            {
                if (x == nth)
                {
                    // Verify the nth instance is still in the current month
                    if (day.Month == month.Month)
                        return day;
                    else
                        return null;
                }
                x++;
            }
            day = day.AddDays(1 * (isReverse ? -1 : 1));
        }
        return null;
        
    }
