    public static class DateTimeExtensionMethods
    {
        public static bool IsValidSqlDateTime(this DateTime dateTime)
        {
            return !(dateTime < (DateTime) SqlDateTime.MinValue ||
                     dateTime > (DateTime) SqlDateTime.MaxValue);
        }
    }
