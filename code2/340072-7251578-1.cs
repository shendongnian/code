    public static class DateTimeHelper
    {
        /// <summary>
        /// Tries to parse the given datetime string that is not annotated with a timezone 
        /// information but known to be in the CET/CEST zone and returns a DateTime struct
        /// in UTC (so it can be converted to the devices local time). If it could not be 
        /// parsed, result contains the current date/time in UTC.
        /// </summary>
        public static bool TryParseCetCest(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result)
        {
            // Parse datetime, knowing it is in CET/CEST timezone. Parse as universal as we fix it afterwards
            if (!DateTime.TryParseExact(s, format, provider, style, out result))
            {
                result = DateTime.UtcNow;
                return false;
            }
            result = DateTime.SpecifyKind(result, DateTimeKind.Utc);
            // The boundaries of the daylight saving time period in CET and CEST (_not_ in UTC!)
            // Both DateTime structs are of kind 'Utc', to be able to compare them with the parsing result
            DateTime DstStart = LastSundayOf(result.Year, 3).AddHours(2);
            DateTime DstEnd = LastSundayOf(result.Year, 10).AddHours(3);
            // Are we inside the daylight saving time period?
            if (DstStart.CompareTo(result) <= 0 && result.CompareTo(DstEnd) < 0)
                result = result.AddHours(-2); // CEST = UTC+2h
            else
                result = result.AddHours(-1); // CET = UTC+1h
            return true;
        }
        /// <summary>
        /// Returns the last sunday of the given month and year in UTC
        /// </summary>
        private static DateTime LastSundayOf(int year, int month)
        {
            DateTime firstOfNextMonth = new DateTime(year, month + 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return firstOfNextMonth.AddDays(firstOfNextMonth.DayOfWeek == DayOfWeek.Sunday ? -7 :
                                                        (-1 * (int)firstOfNextMonth.DayOfWeek));
        }
    }
