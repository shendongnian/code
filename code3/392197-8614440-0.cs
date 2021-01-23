    create a class
    public class TimeConverter
        {
            public static DateTime ConvertToLocalTime(DateTime utcTime, string timeZoneId)
            {
                if (string.IsNullOrEmpty(timeZoneId))
                {
                    return utcTime;
                }
                return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(utcTime, timeZoneId);
            }
    }
    
    In controller use TimeConverter
    
    TimeConverter.ConvertToLocalTime(Date, yourTimeZone));
