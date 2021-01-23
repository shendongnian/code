    // Parse string. We don't need escaping since E,D and T 
    // are not considered special characters by ParseExact.
    var dateTimeInEasternTime = DateTime.ParseExact("Apr 18 2011 19:30 EDT",
                                                    "MMM dd yyyy HH:mm EDT",    
                                                    CultureInfo.InvariantCulture);
    // Convert from the relevant timezone to UTC.
    var dateTimeInUTC = TimeZoneInfo.ConvertTime
                        (dateTimeInEasternTime,  
                         TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), 
                         TimeZoneInfo.Utc);
