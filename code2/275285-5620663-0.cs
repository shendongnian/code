    private static DateTime GetNextDayOccurrence(DayOfWeek day, DateTime startDate)
    {
        if (startDate.DayOfWeek == day)
        {
            return startDate;
        }
        else
        {
            return GetNextDayOccurrence(day, startDate.AddDays(1));
        }
    }
