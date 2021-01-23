    static class DateTimeExtensions
    {
        public static string ToString(this DateTime? dateTime, string format)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToString(format);
            else
                return String.Empty;
        }
    }
