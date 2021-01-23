    public static IEnumerable<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, DayOfWeek weekday, int amounttoshow = 4)
    {
        while(dt.DayOfWeek != weekday)
            dt = dt.AddDays(1);
        for (int i = 0; i < amounttoshow; i++)
        {
            yield return dt;
            dt = dt.AddDays(7);
        }
    }
