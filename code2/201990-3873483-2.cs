    var zones = TimeZoneInfo.GetSystemTimeZones();    // retrieve timezone info
    string value = "09/20/2010 14:30";
    DateTime CompletedDttm = DateTime.ParseExact(value, "MM/dd/yyyy HH:mm",    
        new CultureInfo("en-US"));
    DateTime FinalDttm = TimeZoneInfo.ConvertTime(CompletedDttm, 
        TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), 
        TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
    string output = FinalDttm.ToString(new CultureInfo("en-GB"));
    FinalDttm = TimeZoneInfo.ConvertTime(CompletedDttm, TimeZoneInfo.Local, 
        TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"));
    output = FinalDttm.ToString(new CultureInfo("de-DE"));
