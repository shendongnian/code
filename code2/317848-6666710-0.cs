    if ( dateTimeUtc == DateTime.UtcNow )
    {
        // If your reminder needs to display the local time, pass it in:
        var tzi = TimeZoneInfo.FindSystemTimeZoneById(TimeZneID1);
        SendReminder(TimeZoneInfo.ConvertFromUtc(DateTime.UtcNow, tzi));
    }
