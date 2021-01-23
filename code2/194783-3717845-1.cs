    public static DateTime AddWeekdays(DateTime start, int days)
        {
            int remainder = days % 5;
            int weekendDays = (days / 5) * 2;
            DateTime end = start.AddDays(remainder);
            if (start.DayOfWeek == DayOfWeek.Saturday && days > 0)
            {
                // fix for saturday.
                end = end.AddDays(-1);
            }
            if (end.DayOfWeek == DayOfWeek.Saturday && days > 0)
            {
                // add two days for landing on saturday
                end = end.AddDays(2);
            }
            else if (end.DayOfWeek < start.DayOfWeek)
            {
                // add two days for rounding the weekend
                end = end.AddDays(2);
            }
            // add the remaining days
            return end.AddDays(days + weekendDays - remainder);
        }
