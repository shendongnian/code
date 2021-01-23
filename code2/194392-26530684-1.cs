    private static HashSet<DateTime> GetHolidays(int year) 
        { 
            HashSet<DateTime> holidays = new HashSet<DateTime>();
 
            // New Years
            DateTime newYearsDate = AdjustForWeekendHoliday(new DateTime(year, 1, 1)); 
            holidays.Add(newYearsDate); 
            // Memorial Day -- last monday in May 
            DateTime memorialDay = new DateTime(year, 5, 31); 
            DayOfWeek dayOfWeek = memorialDay.DayOfWeek; 
            while (dayOfWeek != DayOfWeek.Monday) 
            { 
                memorialDay = memorialDay.AddDays(-1); 
                dayOfWeek = memorialDay.DayOfWeek; 
            } 
            holidays.Add(memorialDay); 
            
            // Independence Day
            DateTime independenceDay = AdjustForWeekendHoliday(new DateTime(year, 7, 4)); 
            holidays.Add(independenceDay); 
         
            // Labor Day -- 1st Monday in September 
            DateTime laborDay = new DateTime(year, 9, 1); 
            dayOfWeek = laborDay.DayOfWeek; 
            while(dayOfWeek != DayOfWeek.Monday) 
            { 
                laborDay = laborDay.AddDays(1); 
                dayOfWeek = laborDay.DayOfWeek; 
            } 
            holidays.Add(laborDay);
            // Thanksgiving Day -- 4th Thursday in November 
            var thanksgiving = (from day in Enumerable.Range(1, 30) 
                           where new DateTime(year, 11, day).DayOfWeek == DayOfWeek.Thursday 
                           select day).ElementAt(3); 
            DateTime thanksgivingDay = new DateTime(year, 11, thanksgiving); 
            holidays.Add(thanksgivingDay);
            // Christmas Day 
            DateTime christmasDay = AdjustForWeekendHoliday(new DateTime(year, 12, 25)); 
            holidays.Add(christmasDay); 
            // Next year's new years check
            DateTime nextYearNewYearsDate = AdjustForWeekendHoliday(new DateTime(year + 1, 1, 1));
            if (nextYearNewYearsDate.Year == year)
            holidays.Add(nextYearNewYearsDate);
            return holidays; 
        }
        public static DateTime AdjustForWeekendHoliday(DateTime holiday) 
        { 
            if (holiday.DayOfWeek == DayOfWeek.Saturday) 
            { 
                return holiday.AddDays(-1); 
            } 
            else if (holiday.DayOfWeek == DayOfWeek.Sunday) 
            { 
                return holiday.AddDays(1); 
            } 
            else 
            { 
                return holiday; 
            } 
        }
