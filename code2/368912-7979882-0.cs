    var utcDate1 = new DateTime(2011, 10, 23, 9, 0, 0, DateTimeKind.Utc);
    Console.WriteLine(utcDate1);
    Console.WriteLine(utcDate1.ToLocalTime());
    
    var utcDate2 = new DateTime(2011, 11, 2, 9, 0, 0, DateTimeKind.Utc);
    Console.WriteLine(utcDate2);
    Console.WriteLine(utcDate2.ToLocalTime());
