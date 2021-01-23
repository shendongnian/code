        /// <summary>
        /// Gets the date of the next occurrence of the day of week provided
        /// </summary>
        /// <param name="value"></param>
        /// <param name="nextDay"></param>
        /// <returns></returns>
        public static DateTime NextOccurance(this DateTime value, DayOfWeek nextDay)
        {
            if (value.DayOfWeek == nextDay) { return value; }
            else if (value.DayOfWeek > nextDay) { return value.AddDays(7 - (value.DayOfWeek - nextDay)); }
            else { return value.AddDays(nextDay - value.DayOfWeek); }
        }
        /// <summary>
        /// Gets the date of the last occurrence of the day of week provided
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lastDay"></param>
        /// <returns></returns>
        public static DateTime LastOccurance(this DateTime value, DayOfWeek lastDay)
        {
            if (value.DayOfWeek == lastDay) { return value; }
            else if (value.DayOfWeek > lastDay) { return value.AddDays(-(value.DayOfWeek - lastDay)); }
            else { return value.AddDays((lastDay - value.DayOfWeek) - 7); }
        }
        /// <summary>
        /// Gets the date of the closest occurrence of the day of week provided
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime ClosestOccurance(this DateTime value, DayOfWeek day)
        {
            DateTime before = value.LastOccurance(day);
            DateTime after = value.NextOccurance(day);
            return ((value - before) < (after - value))
                ? before
                : after;
        }
