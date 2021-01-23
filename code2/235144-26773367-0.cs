    public static class DateTimeExtensions
    {
        public static DateTime LastDayOfMonth(this DateTime date)
        {
            return date.AddDays(1-(date.Day)).AddMonths(1).AddDays(-1);
        }
    }
