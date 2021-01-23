    public static DateTime GetNextDayOccurrence(DateTime startDate, DayOfWeek dayOfWeek)
    {
      var offset = startDate.DayOfWeek > dayOfWeek ? 7 : 0;
      var days = (int) dayOfWeek + offset - (int) startDate.DayOfWeek;
      var dateTime = startDate.AddDays(days);
      return dateTime;
    }
