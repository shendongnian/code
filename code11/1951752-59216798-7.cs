    public static bool IsWithinAWeek(string input)
    {
        return DateTime.Today.Subtract(GetDate(input)).TotalDays <= 7;
    }
    public static bool IsWithinAMonth(string input)
    {
        DateTime date = GetDate(input);
        var lastMonth = DateTime.Today.AddMonths(-1);
        return date >= lastMonth && date <= DateTime.Today;
    }
