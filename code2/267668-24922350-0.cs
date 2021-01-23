    public DateTime DateOfWeekOfMonth(int year, int month, DayOfWeek dayOfWeek, byte weekNumber)
    {
        DateTime tempDate = new DateTime(year, month, 1);
        tempDate = tempDate.AddDays(-(tempDate.DayOfWeek - dayOfWeek));
    
        return
            tempDate.Day > (byte)DayOfWeek.Saturday
                ? tempDate.AddDays(7 * weekNumber)
                : tempDate.AddDays(7 * (weekNumber - 1));
    }
    
    public DateTime DateOfWeekOfMonth(DateTime sender, DayOfWeek dayOfWeek, byte weekNumber)
    {
        return DateOfWeekOfMonth(sender.Year, sender.Month, dayOfWeek, weekNumber);
    }
