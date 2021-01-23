    static class DateTimeExtensions
    {
        public static string ToString(this DateTime? dateTime, string format)
        {
            return dateTime.HasValue ? dateTime.Value.ToString(format) : String.Empty;
        }
    }
