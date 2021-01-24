    public static List<TzdbZoneLocation> GetAllTimeZones()
    {
        return TzdbDateTimeZoneSource.Default
                    .ZoneLocations
                    .Where(x => x.CountryCode == "US")
                    .ToList();
    }
