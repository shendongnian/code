	DateTime.Now.DayOfWeek; // returns Sunday
	(int)DateTime.Now.DayOfWeek; // returns 0
	DateTime.Now.DayOfWeek(DayOfWeek.Monday); // returns 6    
    public static class ExtensionMethods
    {
        /// <summary>
        /// Returns an zero-based index where firstDayOfWeek = 0 and lastDayOfWeek = 6
        /// </summary>
        /// <param name="value"></param>
        /// <param name="firstDayOfWeek"></param>
        /// <returns>int between 0 and 6</returns>
        public static int DayOfWeek(this DateTime value, DayOfWeek firstDayOfWeek)
        {
            var idx = 7 + (int)value.DayOfWeek - (int)firstDayOfWeek;
            if (idx > 6) // week ends at 6, because Enum.DayOfWeek is zero-based
            {
                idx -= 7;
            }
            return idx;
        }
    }
