    ReadOnlyCollection<TimeZoneInfo> zones = TimeZoneInfo.GetSystemTimeZones();
    Console.WriteLine("The local system has the following {0} time zones", zones.Count);
    foreach (TimeZoneInfo zone in zones.OrderBy(z => z.Id))
        Console.WriteLine(zone.Id);
    Console.ReadLine();
