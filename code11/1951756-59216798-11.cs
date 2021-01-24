    public static bool IsWithinAWeekBeforeToday(string input)
    {
        var date = GetDate(input);
        return date <= DateTime.Today && 
               DateTime.Today.Subtract(date).TotalDays <= 7;
    }
    public static bool IsWithinAMonthBeforeToday(string input)
    {
        var date = GetDate(input);
        var lastMonth = DateTime.Today.AddMonths(-1);
        return date >= lastMonth && 
               date <= DateTime.Today;
    }
