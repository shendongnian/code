    var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    
    var times = new DateTime[] {
        new DateTime (2010, 11, 7, 4,  0, 0, DateTimeKind.Utc),
        new DateTime (2010, 11, 7, 5,  0, 0, DateTimeKind.Utc),
        new DateTime (2010, 11, 7, 5, 30, 0, DateTimeKind.Utc),
        new DateTime (2010, 11, 7, 6,  0, 0, DateTimeKind.Utc),
    };
    
    Console.WriteLine("     Time  | IsDaylightSaving | IsAmbiguousTime");
    foreach (var t in times) {
        var time = TimeZoneInfo.ConvertTimeFromUtc(t, est);
        Console.WriteLine ("    {0:HH:mm}  | {1,11}      |      {2,5}", time, est.IsDaylightSavingTime(time), est.IsAmbiguousTime(time));
    }
