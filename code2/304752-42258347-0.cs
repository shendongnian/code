    public static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> Next(this DateTime date, DayOfWeek day)
        {
            while(true)
            {
                if (date.DayOfWeek == day)
                {
                    yield return date;
                }
                date = date.AddDays(1);
            }
        }
    }
