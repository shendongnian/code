    public static class DateTimeExtensions
    {
        public static DateTime AddWeeks(this DateTime DT, int Weeks)
        {
            return DT.AddDays(Weeks * 7);
        }
    }
