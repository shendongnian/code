    private static DateTime FindTheNthDayOfWeek(int year, int month, int nthOccurrence, DayOfWeek dayOfWeek)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("Invalid month");
            }
 
            if (nthOccurrence < 0 || nthOccurrence > 5)
            {
                throw new ArgumentOutOfRangeException("Invalid nth occurrence");
            }
 
            var dt = new DateTime(year, month, 1);
 
            while (dt.DayOfWeek != dayOfWeek)
            {
                dt = dt.AddDays(1);
            }
 
            dt = dt.AddDays((nthOccurrence - 1) * 7);
 
            if (dt.Month != month)
            {
                throw new ArgumentOutOfRangeException(string.Format("The given month has less than {0} {1}s", nthOccurrence, dayOfWeek));
            }
 
            return dt;
        }
