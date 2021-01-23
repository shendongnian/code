    static class DateTimeExtensions
    {
        public static IEnumerable<DateTime> GetHours(this DateTime date)
        {
            date = date.Date; // truncate hours
            for(int i = 0; i < 24; i++)
            {
                yield return date.AddHours(i);
            }
        }
    }
    ...
    DateTime date = new DateTime(2011,12,15);
    foreach (DateTime time in date.GetHours())
    {
        ...
    }
