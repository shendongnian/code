    public static DateTime GetLastSunday()
    {
        DateTime today = DateTime.Today;
        return today.AddDays(-((int)today.DayOfWeek));
    }
