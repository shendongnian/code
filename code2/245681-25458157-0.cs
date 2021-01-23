    public static DateTime FirstDateOfCalendarMonth(this DateTime dt, DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
    {
      dt = new DateTime(dt.Year, dt.Month, 1);
      while (dt.DayOfWeek != firstDayOfWeek){
        dt = dt.AddDays(-1);
      }
      return dt;
    }
