    public static bool IsWithinAWeek(string date)
    {
        return IsWithinDays(date, 7);
    }
    public static bool IsWithinAMonth(string date)
    {
        return IsWithinDays(date, 30);
    }
