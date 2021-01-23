        // Determine if 'localtime' is in the second duplicate DST hour.
        public static Boolean isSecondHour(TimeZoneInfo localzone, DateTime localtime, DateTime UTCtime)
        {     
            if (localzone.IsAmbiguousTime(localtime))
            {
                // UTC time + UTC offset = second hour time (not first hour)
                return UTCtime.Add(localzone.GetUtcOffset(localtime)) == localtime;
            }
            else
                return false;
        }
        // Convert Local time to UTC, with 'SecondDST' indicating if hour is the second hour of autumn DST change.
        public static DateTime Convert_to_UTC(TimeZoneInfo localzone, DateTime localtime, Boolean SecondDST)
        {
            DateTime newUTC = TimeZoneInfo.ConvertTimeToUtc(localtime, localzone);
            if (localzone.IsAmbiguousTime(localtime) && !SecondDST)
            {
                TimeZoneInfo.AdjustmentRule rul = GetDSTrule(localtime.Year, localzone);
                return newUTC.Add(-rul.DaylightDelta);
            }
            else
                return newUTC;
         }
 
      // Get the DST rule for the year and zone  (rules may change from year to year as in 2004)
            public static TimeZoneInfo.AdjustmentRule GetDSTrule(int Year, TimeZoneInfo zone)
            {
                TimeZoneInfo.AdjustmentRule[] rules = zone.GetAdjustmentRules();
                foreach (TimeZoneInfo.AdjustmentRule rul in rules)
                {
                    if (rul.DateStart < new DateTime(Year, 1, 1) && rul.DateEnd > new DateTime(Year, 1, 1))
                    {
                        return rul;
                    }
                }
                return null;
            }
