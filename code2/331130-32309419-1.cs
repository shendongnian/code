    public static class DateTimeExtensions
    {
        public static DateTime RoundUp(this DateTime dt, TimeSpan ts)
        {
            return Round(dt, ts, true);
        }
        public static DateTime RoundDown(this DateTime dt, TimeSpan ts)
        {
            return Round(dt, ts, false);
        }
        private static DateTime Round(DateTime dt, TimeSpan ts, bool up)
        {
            var remainder = dt.Ticks % ts.Ticks;
            if (remainder == 0)
            {
                return dt;
            }
            long delta;
            if (up)
            {
                delta = ts.Ticks - remainder;
            }
            else
            {
                delta = -remainder;
            }
            return dt.AddTicks(delta);
        }
    }
