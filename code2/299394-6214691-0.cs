    var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    
    var times = new DateTime[] {
        new DateTime (2010, 11, 7, 0,  0, 0, DateTimeKind.Unspecified),
        new DateTime (2010, 11, 7, 1,  0, 0, DateTimeKind.Unspecified),
        new DateTime (2010, 11, 7, 1, 30, 0, DateTimeKind.Unspecified),
        new DateTime (2010, 11, 7, 2,  0, 0, DateTimeKind.Unspecified),
    };
    
    Console.WriteLine(" Time  | IsDaylightSaving | IsAmbiguousTime");
    foreach (var t in times) {
        Console.WriteLine ("{0:HH:mm}  | {1,11}      |      {2,5}", t, est.IsDaylightSavingTime(t), est.IsAmbiguousTime(t));
    }
