    var firstDayOfMonth = new DateTime(year, month, 1);
    DateTime startOfCalendar = 
        FirstDayOfWeekOnOrBefore(
            firstDayOfMonth,
            DayOfWeek.Monday
        );
    public static DateTime FirstDayOfWeekOnOrBefore(
        DateTime date,
        DayOfWeek dayOfWeek
    ) {
        while(date.DayOfWeek != dayOfWeek) {
            date = date.AddDays(-1);
        }
        return date;
    }
