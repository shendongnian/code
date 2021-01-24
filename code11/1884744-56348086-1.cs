    static List<string> GetTimeZonesAtMidnight(Instant instant, LocalTime timeOfDay) =>
        // Extension method in NodaTime.Extensions.DateTimeZoneProviderExtensions
        DateTimeZoneProviders.Tzdb.GetAllZones()
            .Where(zone => instant.InZone(zone).TimeOfDay == timeOfDay)
            .Select(zone => zone.Id)
            .ToList();
