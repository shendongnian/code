    public static DateTime? GetNthWeekDay(int nth, List<DayOfWeek> weekdays, DateTime month)
    { 
        var day = new DateTime(month.Year, month.Month, 1);
        var dayCount = weekdays.Count;
        if (dayCount == 0)
            return null;
        // Can fast-forward to the closest week
        var z = (nth / dayCount);
        day = day.AddDays(z * 7);
        // Set x equal to the current Nth count after the fast-forward
        var x = 1 + (z * dayCount);
        // Nth instance should be within the next 7 days, so loop through them and find it
        while (x <= nth)
        {
            if (weekdays.Contains(day.DayOfWeek))
            {
                if (x == nth)
                {
                    // Return null if the Nth instance isn't in the specified month
                    if (day.Month == month.Month)
                        return day;
                    else
                        return null;
                }
                    
                x++;
            }
            day = day.AddDays(1);
        }
        return null;
    }
