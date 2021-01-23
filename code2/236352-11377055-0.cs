    public static class TimeSpanHelper
    {        
        public static TimeSpan Parse(string timeString)
        {
            var dt = DateTime.ParseExact(timeString, "H:mm tt", System.Globalization.CultureInfo.InvariantCulture);            
            return dt.TimeOfDay;
        }
    }
