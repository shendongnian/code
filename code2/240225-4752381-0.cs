    DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
    string easternZoneId = "Eastern Standard Time";
    try
    {
       TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
       Console.WriteLine("The date and time are {0} UTC.", 
                         TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone));
    }
    catch (TimeZoneNotFoundException)
    {
       Console.WriteLine("Unable to find the {0} zone in the registry.", 
                         easternZoneId);
    }                           
    catch (InvalidTimeZoneException)
    {
       Console.WriteLine("Registry data on the {0} zone has been corrupted.", 
                         easternZoneId);
    }
