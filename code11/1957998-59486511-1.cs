    var dateTimeString = "20181230183000000";
    DateTimeOffset dto;
    if (DateTimeOffset.TryParseExact(dateTimeString, "yyyyMMddHHmmssfff", 
                                     CultureInfo.InvariantCulture, 
                                     DateTimeStyles.AssumeUniversal |
                                     DateTimeStyles.AdjustToUniversal, out dto))
    
    {
         Console.WriteLine(dto);
    }
