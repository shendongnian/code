     public static DateTime GetDayOfMonth(DateTime dateValue, DayOfWeek dayOfWeek, int occurance)
        {
            List<DateTime> dayOfWeekRanges = new List<DateTime>();
            //move to the first of th month
            DateTime startOfMonth = new DateTime(dateValue.Year, dateValue.Month, 1);
            //move startOfMonth to the dayOfWeek requested
            while (startOfMonth.DayOfWeek != dayOfWeek)
                startOfMonth = startOfMonth.AddDays(1);
            do
            {
                dayOfWeekRanges.Add(startOfMonth);
                startOfMonth = startOfMonth.AddDays(7);
            } while (startOfMonth.Month == dateValue.Month);
            bool fromLast = occurance < 0;
            if (fromLast)
                occurance = occurance * -1;
            if (fromLast)
                return dayOfWeekRanges[dayOfWeekRanges.Count - occurance];
            else
                return dayOfWeekRanges[occurance - 1];
        }
