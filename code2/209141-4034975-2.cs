    DateTime ceTime = new DateTime(2007, 02, 01, 08, 00, 00);
    try
    {
       TimeZoneInfo ceZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard        Time");
       TimeZoneInfo gmtZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
       Console.WriteLine("{0} {1} is {2} GMT time.", 
               ceTime, 
               ceZone.IsDaylightSavingTime(ceTime) ? ceZone.DaylightName : ceZone.StandardName, 
               TimeZoneInfo.ConvertTime(ceTime, ceZone, gmtZone));
    }
    catch (TimeZoneNotFoundException)
    {
       Console.WriteLine("The registry does not define the required timezones.");
    }                           
    catch (InvalidTimeZoneException)
    {
       Console.WriteLine("Registry data on the required timezones has been corrupted.");
    }
