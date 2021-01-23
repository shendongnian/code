    private static long ConvertFileTime(long fileTime)
    {
        var dateTime = DateTime.FromFileTime(fileTime);
        var localDateTime = TimeZone.CurrentTimeZone.ToLocalTime(dateTime);
        return new DateTime(localDateTime.Ticks, DateTimeKind.Unspecified).ToFileTimeUtc();
    }
