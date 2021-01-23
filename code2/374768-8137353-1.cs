    public DateTime GetFirstDayOfFirstWeek(int year, CultureInfo culture)
    {
        // calc first date of this week
        var firstDateOfWeek = new DateTime(year, 1, 10);
        while (firstDateOfWeek.DayOfWeek != culture.DateTimeFormat.FirstDayOfWeek)
            firstDateOfWeek = firstDateOfWeek.AddDays(-1);
        // get current week number
        int weekNum = culture.Calendar.GetWeekOfYear(firstDateOfWeek, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek);
        // remove all weeks except the first one
        return firstDateOfWeek.AddDays(7 - (weekNum * 7));
    }
    var date = GetFirstDayOfFirstWeek(2009, new CultureInfo("sv-se"));
