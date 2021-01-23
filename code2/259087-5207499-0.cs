    DateTimeOffset nowDateTime = DateTimeOffset.Now;
    DateTimeOffset newDateTime = TimeZoneInfo.ConvertTime(
        nowDateTime,
        TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time"));
    Console.WriteLine("Now: {0}", nowDateTime);
    Console.WriteLine("Now in Hawaii: {0}", newDateTime);
