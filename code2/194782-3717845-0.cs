    public static DateTime AddWeekdays(DateTime start, int days)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new ArgumentException("start must be a weekday");
            }
            int remainder = days % 5;
            int weekendDays = (days / 5) * 2;
            DateTime end = start.AddDays(remainder);
            if (end.DayOfWeek == DayOfWeek.Saturday)
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
