    DateTimeZone belgradeZone = DateTimeZone.ForId("Europe/Belgrade"); // Or whatever
    // Alternatively...
    DateTimeZone localZone = DateTimeZone.SystemDefault;
    ZonedDateTime utc = new ZonedDateTime(2011, 10, 23, 9, 0, 0, DateTimeZone.Utc);
    ZonedDateTime belgrade = new ZonedDateTime(utc.ToInstant(), belgradeZone);
    Console.WriteLine(belgrade.LocalDateTime);
