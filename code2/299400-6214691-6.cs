    var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    
    var times = new DateTimeOffset[] {
        new DateTimeOffset (2010, 11, 7, 4, 00, 0, TimeSpan.Zero),
        new DateTimeOffset (2010, 11, 7, 5, 00, 0, TimeSpan.Zero),
        new DateTimeOffset (2010, 11, 7, 5, 30, 0, TimeSpan.Zero),
        new DateTimeOffset (2010, 11, 7, 6, 00, 0, TimeSpan.Zero),
    };
    
    Console.WriteLine("     Time  | IsDaylightSaving | IsAmbiguousTime");
    foreach (var t in times) {
        var time = TimeZoneInfo.ConvertTime (t, est);
        Console.WriteLine ("    {0:HH:mm}  | {1,11}      |      {2,5}", time, est.IsDaylightSavingTime(time), est.IsAmbiguousTime(time));
    }
