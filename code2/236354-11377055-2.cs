    public static class TimeSpanHelper
    {        
        public static TimeSpan ToTimeSpan(this string timeString)
        {
            var dt = DateTime.ParseExact(timeString, "H:mm tt", System.Globalization.CultureInfo.InvariantCulture);            
            return dt.TimeOfDay;
        }
    }
