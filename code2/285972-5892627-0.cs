    public static class DateTimeExtensions
    {
        public static DateTime SubtractBusinessDays(this DateTime fromDateTime, int days)
        {
            var subtractDays = days % 5;
            var dayNumber = fromDateTime.DayOfWeek == DayOfWeek.Sunday ? 7 : (int)fromDateTime.DayOfWeek;
            var addDays = Math.Max(dayNumber - 5, 0);
            var result = fromDateTime.AddDays(addDays - subtractDays - (days / 5 * 7));
            if ((addDays + dayNumber) % 7 <= subtractDays)
                result = result.AddDays(-2);
            return result;
        }
    }
