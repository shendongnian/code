    public static class Extensions
    {
        public static DateTime ToFirstDateOfMonth(this DateTime input)
        {
            return new DateTime(input.Year, input.Month, 1, input.Hour, 
                input.Minute, input.Second, input.Millisecond, input.Kind);
        }
        public static DateTime ToLastDateOfMonth(this DateTime input)
        {
            return new DateTime(input.Year, input.Month, 
                DateTime.DaysInMonth(input.Year, input.Month), input.Hour,
                input.Minute, input.Second, input.Millisecond, input.Kind);
        }
    }
