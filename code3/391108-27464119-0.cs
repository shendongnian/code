    public static DateTime DateNow()
            {
                DateTime utcTime = DateTime.UtcNow;
                TimeZoneInfo myZone = TimeZoneInfo.CreateCustomTimeZone("COLOMBIA", new TimeSpan(-5, 0, 0), "Colombia", "Colombia");
                DateTime custDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, myZone);
                return custDateTime;   
            }
