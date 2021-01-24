    public static class CalendarExt {
        public static int GetISO8601WeekOfYear(this DateTime aDate) => ISOWeek.GetWeekOfYear(aDate);
        public static DateTime FirstDateOfYear(this DateTime d) => new DateTime(d.Year, 1, 1);
        public static DateTime FirstDateOfISO8601Week(this DateTime aDate) => aDate.AddDays(-(((int)aDate.DayOfWeek + 6) % 7));
        public static DateTime LastDateofISO8601Week(this DateTime aDate) => aDate.FirstDateOfISO8601Week().AddDays(6);    
        public static DateTime FirstDateOfISO8601Week(int year, int weekNum) => ISOWeek.ToDateTime(year, weekNum, DayOfWeek.Monday);
        public static DateTime LastDateofISO8601Week(int year, int weekNum) => FirstDateOfISO8601Week(year, weekNum).AddDays(6);    
        // for .Net without ISOWeek
        //public static DateTime FirstDateOfISO8601Week(this DateTime aDate) => aDate.AddDays(-(((int)aDate.DayOfWeek + 6) % 7));
        //public static int GetISO8601WeekOfYear(this DateTime aDate) =>
        //    CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(aDate.AddDays(DayOfWeek.Monday <= aDate.DayOfWeek && aDate.DayOfWeek <= DayOfWeek.Wednesday ? 3 : 0), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }
