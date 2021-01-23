    DateTimeOffset clientNow = TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow,
                                                        timeZone);
    if (clientNow.TimeOfDay == TimeSpan.FromHours(20))
    {
        // ...
    }
