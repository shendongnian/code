    using System;
    
    // ReSharper disable once CheckNamespace
    public static class BrazilTime
    {
        public static DateTime Now
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            }
        }
    }
