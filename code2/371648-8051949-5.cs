    public static DateTime GetDayOfThisWeek(DayOfWeek dayOfWeek)
    {
        DateTime today = DateTime.Today;
        DateTime lastSunday = today.AddDays(-((int)today.DayOfWeek));
        return lastSunday.AddDays((int)dayOfWeek);
    }
