           var est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            var times = new DateTime[] {
            new DateTime (2010, 11, 7, 3,  0, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 4,  0, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 5,  0, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 5,  30, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 6,  0, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 6,  30, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 7,  0, 0, DateTimeKind.Unspecified),
            new DateTime (2010, 11, 7, 8,  0, 0, DateTimeKind.Unspecified)
                
        };
        // ------------------ UTC to Eastern  
   
        DateTime EasternTime;
        Console.WriteLine("UTC Time  |  Est Time   | IsDaylightSaving | IsAmbiguousTime | isSecondHour ");
        foreach (var utc in times)
        {
            // Get Eastern Time from UTC using standard convert routine.
            EasternTime = TimeZoneInfo.ConvertTimeFromUtc(utc, est);
            Console.WriteLine("{0:HH:mm}     |   {1:HH:mm}     | {2,11}      |      {3,5}      |      {4,5}", utc,EasternTime, est.IsDaylightSavingTime(EasternTime), est.IsAmbiguousTime(EasternTime),isSecondHour(est,EasternTime, utc));
         }
            // ------------------ Eastern  to UTC    
        DateTime testTime;
        Console.WriteLine("UTC Time  |  Est Time   | IsDaylightSaving | IsAmbiguousTime | isSecondHour ");
        EasternTime = new DateTime(2010, 11, 7, 1, 30, 0, DateTimeKind.Unspecified);
        // First Hour of DST
        testTime = Convert_to_UTC (est, EasternTime,false);
        Console.WriteLine("{0:HH:mm}     |   {1:HH:mm}     | {2,11}      |      {3,5}      |      {4,5}", testTime, EasternTime, est.IsDaylightSavingTime(EasternTime), est.IsAmbiguousTime(EasternTime), isSecondHour(est, EasternTime, testTime));
        // Second Hour of DST
        testTime = Convert_to_UTC(est, EasternTime, true);
        Console.WriteLine("{0:HH:mm}     |   {1:HH:mm}     | {2,11}      |      {3,5}      |      {4,5}", testTime, EasternTime, est.IsDaylightSavingTime(EasternTime), est.IsAmbiguousTime(EasternTime), isSecondHour(est, EasternTime, testTime));
