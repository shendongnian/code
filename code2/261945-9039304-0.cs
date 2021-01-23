    public static DateTime LocalDateTimeFromUtc(DateTime utcDateTime)
    {   
        DateTimeOffset dateTimeOffset = new DateTimeOffset(utcDateTime, new TimeSpan(0, 0, 0));
        DateTimeOffset dateTimeOffsetConvertedToLocal = TimeZoneInfo.ConvertTime(dateTimeOffset, TimeZoneInfo.Local);
        return dateTimeOffsetConvertedToLocal.DateTime;
    }
