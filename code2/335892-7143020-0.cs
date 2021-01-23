    string dateStr = "2011-03-18T12:07:00.000+10:00"; //Convert this string to datetime AS IS
    
    DateTime localDateTime = DateTime.Parse(date); 
    
    DateTime utcDateTime = localDateTime.ToUniversalTime();
    string estKey = "Eastern Standard Time";
    TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById(estKey);
    DateTime estDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, estTimeZone);
    
    Console.WriteLine("Original string: " + dateStr);
    Console.WriteLine("date toString:   " + estDateTime);
