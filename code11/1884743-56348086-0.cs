    static List<string> GetTimeZonesAtMidnight(Instant instant) =>
        // Extension method in NodaTime.Extensions.DateTimeZoneProviderExtensions
        DateTimeZoneProviders.Tzdb.GetAllZones()
            .Where(zone => instant.InZone(zone).TimeOfDay == LocalTime.Midnight)
            .Select(zone => zone.Id)
            .ToList();
