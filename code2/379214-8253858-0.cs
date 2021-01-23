    public static class DateExtensions
    {
        public static bool IsBusinessDay(this DateTime date)
        {
            return
                date.DayOfWeek != DayOfWeek.Saturday &&
                date.DayOfWeek != DayOfWeek.Sunday;
        }
        public static int BusinessDaysTo(this DateTime fromDate, DateTime toDate)
        {
            int ret = 0;
            DateTime dt = fromDate;
            while (dt < toDate)
            {
                if (dt.IsBusinessDay()) ret++;
                dt = dt.AddDays(1);
            }
            return ret;
        }
    }
