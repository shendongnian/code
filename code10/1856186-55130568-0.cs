    // Retrieve the time zone for Eastern Standard Time (U.S. and Canada).
       TimeZoneInfo est; 
         try {
            est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
         }
         catch (TimeZoneNotFoundException) {
         Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
            return;
         }
         catch (InvalidTimeZoneException) {
            Console.WriteLine("Unable to retrieve the Eastern Standard time zone.");
            return;
         }
    
    //Create a converted time zone DateTime object
    DateTime targetTime = TimeZoneInfo.ConvertTime(timeToConvert, est);
    
    //Run search request
    var searchRequest = new TransactionSearchRequest().
        CreatedAt.GreaterThanOrEqualTo(targetTime.AddDays(-1));  
