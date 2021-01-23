    public static class GregorianCalendarExtensions
    {
        private const int DaysInWeek = 7;
        public static int GetDaysFromStartOfFirstWeekOfYear(
            this GregorianCalendar calendar,
            DateTime time,
            CalendarWeekRule rule,
            DayOfWeek firstDayOfWeek)
        {
            DayOfWeek dayOfWeek = calendar.GetDayOfWeek(time);
            // Calculate 0-index day of week relative to first day of week.
            int completedDaysInWeek =
                ((int)dayOfWeek + DaysInWeek - (int)firstDayOfWeek) % DaysInWeek;
            // Decrement week of year by 1 to give count of completed weeks.
            int completedWeeksInYear =
                calendar.GetWeekOfYear(time, rule, firstDayOfWeek) - 1;
            
            // Increment by one to start counting from 1 rather than 0.
            return (completedWeeksInYear * DaysInWeek) + completedDaysInWeek + 1;
        }
    }
