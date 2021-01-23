    public static class Extensions
    {
        public static DateTimeOffset ToCentralTime(this DateTimeOffset value)
        {
            return TimeZoneInfo.ConvertTime(value, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
        }
    }
