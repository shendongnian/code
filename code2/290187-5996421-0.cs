    foreach (TimeZoneInfo nextZone in TimeZoneInfo.GetSystemTimeZones())
    {
        int nextHours = nextZone.BaseUtcOffset.Hours + 24;     // To prevent negative numbers
        int nextMinutes = nextZone.BaseUtcOffset.Minutes;
        if (tzHours == nextHours && tzMinutes == nextMinutes)
        {
            myTimeZoneInfo = nextZone;
            break;
        }
    }
