    using NodaTime;
    using NodaTime.TimeZones;
    ...
    public TimeZoneInfo GetTimeZoneInfoForTzdbId(string tzdbId)
    {
      var mappings = TzdbDateTimeZoneSource.Default.WindowsMapping.MapZones;
      var map = mappings.FirstOrDefault(x =>
          x.TzdbIds.Any(z => z.Equals(tzdbId, StringComparison.OrdinalIgnoreCase)));
      return map == null ? null : TimeZoneInfo.FindSystemTimeZoneById(map.WindowsId);
    }
