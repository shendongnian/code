    using System;
    using System.Collections.Generic;
    using NodaTime;
    
    namespace TimeZones
    {
        class Program
        {
            static void Main(string[] args)
            {
                Instant utcDateTime = Instant.FromDateTimeUtc(DateTime.UtcNow);
                Console.WriteLine(utcDateTime);
                List<string> zoneIds = GetTimeZonesWithCondition(utcDateTime, 0, 0);
                
                Console.ReadLine();
            }
    
            static List<string> GetTimeZonesWithCondition(Instant utcDateTime, int hourComparison, int minuteComparison)
            {
                List<string> zoneIdsCheck = new List<string>();
                IDateTimeZoneProvider timeZoneProvider = DateTimeZoneProviders.Tzdb;
    
                foreach (var id in timeZoneProvider.Ids)
                {
                    var zone = timeZoneProvider[id];
                    var zoneDateTime = utcDateTime.InZone(zone);
    
                    int hourZone = zoneDateTime.Hour;
                    int minuteZone = zoneDateTime.Minute;
    
                    if (hourZone == hourComparison && minuteZone == minuteComparison)
                    {
                        zoneIdsCheck.Add(zone.ToString());
                        Console.WriteLine($"{zone} / {zoneDateTime}");
                    }
                }
    
                return zoneIdsCheck;
            }
        }
    }
