    public static class TimeTools
    {
        private static readonly DateTime StartOfEpoch = 
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToUnixTime(this DateTime dt)
        {
            return Convert.ToInt64(
                (dt.ToUniversalTime() - StartOfEpoch).TotalSeconds);
        }
    }
