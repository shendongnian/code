        /// <summary>
        /// Returns the day that is the specific day of week of the input day.
        /// </summary>
        /// <param name="input">The input day.</param>
        /// <param name="dayOfWeek">0 is Monday, 6 is Sunday.</param>
        /// <returns></returns>
        public static DateTime GetDayOfWeekOfSpecific(DateTime input, int dayOfWeek)
        {
            if(input.DayOfWeek == DayOfWeek.Sunday)
            {
                dayOfWeek -= 7;
            }
            // lastMonday is always the Monday before nextSunday.
            // When today is a Sunday, lastMonday will be tomorrow.     
            int offset = input.DayOfWeek - DayOfWeek.Monday;
            DateTime lastMonday = input.AddDays(-offset);
            DateTime nextDayOfWeek = lastMonday.AddDays(dayOfWeek);
            return nextDayOfWeek;
        }
