    public static class DateTimeHelper
    {
        public static IEnumerable<DateTime> GetHalfHours(this DateTime dt)
        {
            TimeSpan ts = TimeSpan.FromMinutes(30);
            DateTime time = dt;
            while(true)
            {
                yield return time;
                time.Add(ts);
            }
        }
    }
