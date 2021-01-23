        /// <summary>
        /// Expands the month.
        /// | <  |        Jan  2011       |  > |
        /// ------------------------------------
        /// | Mo | Tu | We | Th | Fr | Sa | Su |
        /// |[27]| 28 | 29 | 30 | 31 | 01 | 02 |
        /// | 03 | 04 | 05 | 06 | 07 | 08 | 09 |
        /// | .. | .. | .. | .. | .. | .. | .. |
        /// | .. | .. | .. | .. | .. | .. | .. |
        /// | 31 | 01 | 02 | 03 | 04 | 05 | 06 |
        /// </summary>
        /// <param name="start">Some day in the month of interest, the start date is updated to become the date of firstDayInCalendar</param>
        /// <returns>The number of days to show. This value is either (28, 35 or 42)</returns>
        public static int ExpandMonth(ref DateTime start)
        {
            DateTime first = new DateTime(start.Year, start.Month, 1);
            DateTime last = new DateTime(start.Year, start.Month, DateTime.DaysInMonth(start.Year, start.Month));
            start = first.AddDays(-((int)first.DayOfWeek + 6) % 7);
            last = last.AddDays(7 - ((int)last.DayOfWeek + 6) % 7);
            return last.Subtract(start).Days;
        }
