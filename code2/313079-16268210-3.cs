    using NodaTime;
    ...
    Instant now = SystemClock.Instance.Now;
    DateTimeZone zone1 = DateTimeZoneProviders.Tzdb.GetSystemDefault();
    LocalDate todayInTheSystemZone = now.InZone(zone1).Date;
    DateTimeZone zone2 = DateTimeZoneProviders.Tzdb["America/New_York"];
    LocalDate todayInTheOtherZone = now.InZone(zone2).Date;
