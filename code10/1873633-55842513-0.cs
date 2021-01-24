     DateTime hwTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Arab Standard Time");
            //DateTime hwTime = new DateTime();
            try
            {
                TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time");
                Console.WriteLine("{0} {1} is {2} local time.",
                        hwTime,
                        hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName,
                        TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Arab Standard Time zone.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Arab Standard Time zone has been corrupted.");
            }
