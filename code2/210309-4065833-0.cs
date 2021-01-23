    public static int GetWeekNumber(this DateTime dtPassed)
    {
        CultureInfo ciCurr = CultureInfo.CurrentCulture;
        DateTimeFormatInfo fiCurr = DateTimeFormatInfo.CurrentInfo;
        int weekNum = ciCurr.Calendar.GetWeekOfYear(dtPassed, fiCurr.CalendarWeekRule, fiCurr.FirstDayOfWeek);
        return weekNum;
    }
