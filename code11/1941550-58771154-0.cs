    public static int CountOfWeekEnds(DateTime start, DateTime end) {
        return CountDays(DayOfWeek.Saturday, start, end) + CountDays(DayOfWeek.Sunday, start, end);
    }
    public static int CountDays(DayOfWeek day, DateTime start, DateTime end)
    {
        TimeSpan ts = end - start;                       // Total duration
        int count = (int)Math.Floor(ts.TotalDays / 7);   // Number of whole weeks
        int remainder = (int)(ts.TotalDays % 7);         // Number of remaining days
        int sinceLastDay = end.DayOfWeek - day;          // Number of days since last [day]
        if (sinceLastDay < 0) sinceLastDay += 7;         // Adjust for negative days since last [day]
        // If the days in excess of an even week are greater than or equal to the number days since the last [day], then count this one, too.
        if (remainder >= sinceLastDay) count++;          
        return count;
    }
