    DateTime targetDateTime = new DateTime(2019, 03, 19, 14, 23, 00, DateTimeKind.Local);
    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    long unixDateTime = (targetDateTime.ToUniversalTime() - epoch).Ticks;
    
     //Add the ticks back to the epoch
     var utcTime = epoch.AddTicks(unixDateTime);
     DateTime localDateTime = utcTime.ToLocalTime();
