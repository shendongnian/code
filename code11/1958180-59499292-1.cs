    var dateTimeString = "20181230_183";
    DateTimeOffset dto;
    if (DateTimeOffset.TryParseExact(dateTimeString, "yyyyMMdd_fff", 
                                     CultureInfo.InvariantCulture, 
                                     DateTimeStyles.AssumeUniversal |
                                     DateTimeStyles.AdjustToUniversal, out dto))
    
    {
         Console.WriteLine(dto.ToString("yyyyMMdd"));  // prints 20181230
         Console.WriteLine(dto.ToString("fff")); // prints 183
    }
