    // when recording date time
    DateTime utcDateTime = DateTime.UtcNow;
    // parse DateTime back out from string
    DateTime utcDateTime = DateTime.SpecifyKind(DateTime.Parse(dateStr),
                                                DateTimeKind.Utc);
    // localized DateTime
    DateTime localDate = utcDateTime.ToLocalTime();
    // fixed DateTime based on timezone
    string timeZoneKey = "New Zealand Standard Time";
    TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneKey);
    DateTime nzlocalDate = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, timeZone);
