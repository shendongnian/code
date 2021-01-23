    ReadOnlyCollection<TimeZoneInfo> tzCollection = TimeZoneInfo.GetSystemTimeZones();
    foreach (TimeZoneInfo tz in tzCollection)
    { 
        int diff = tz.BaseUtcOffset.TotalMinutes;
        string title = tz.DisplayName;
        ...
    }
