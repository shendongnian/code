    var dt = new DateTime(2011, 5, 21, 11, 0, 0);
    foreach (var tzi in TimeZoneInfo.GetSystemTimeZones())
    {
        Console.WriteLine(string.Format("Time in {0} is {1}", tzi.DisplayName, TimeZoneInfo.ConvertTimeFromUtc(dt, tzi)));
    }
