    public int DaysLeft(DateTime startDate, DateTime endDate, Boolean excludeWeekends, String excludeDates)
    {
        //Work out days in range
        int days = (int)endDate.Subtract(startDate).TotalDays + 1;
        if (excludeWeekends)
        {
            //Remove most weekends by removing 2 in 7 days (rounded down)
            days -= ((int)Math.Floor((decimal)(days / 7)) * 2);
            if (startDate.DayOfWeek == DayOfWeek.Sunday) days -= 1;
            if (startDate.DayOfWeek == DayOfWeek.Saturday) days -= 2;
        }                  
        return days;
    }
