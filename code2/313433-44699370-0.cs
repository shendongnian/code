     public static class DateExtension
    {
        public static bool IsNullOrDefault(this DateTime? value)
        {
            return default(DateTime) == value || default(DateTime?) == value;
        }
    }
