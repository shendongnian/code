    public static class DateTimeExtensions
    {
      public static DateTime FirstDayOfMonth(this DateTime dt)
      {
        return new DateTime(dt.Year, dt.Month, 1);
      }
    }
