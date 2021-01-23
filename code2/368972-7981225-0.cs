    public static IEnumerable<DateTime> ReturnNextNthWeekdaysOfMonth(DateTime dt, DayOfWeek weekday, int amounttoshow = 4)
    {
        var day = dt.DayOfWeek == weekday ? dt : dt.AddDays(weekday - dt.DayOfWeek);
        for (int i = 0; i < amounttoshow; i++)
        {
            yield return day;
            day = day.AddDays(7);
        }
    }
