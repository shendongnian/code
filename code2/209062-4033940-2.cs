    // No state in method, so made it static
    public static bool InBetweenDaysInclusive(DateTime date, DayOfWeek start, DayOfWeek end)
    {
        DayOfWeek curDay = date.DayOfWeek;
        if (start <= end)
        {
            // Test one range: start to end
            return (start <= curDay && curDay <= end);
        }
        else
        {
            // Test two ranges: start to 6, 0 to end
            return (start <= curDay || curDay <= end);
        }
    }
