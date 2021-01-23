        /// <summary>
        /// Gets the total number of years between two dates, rounded to whole months.
        /// Examples: 
        /// 2011-12-14, 2012-12-15 returns 1.
        /// 2011-12-14, 2012-12-14 returns 1.
        /// 2011-12-14, 2012-12-13 returns 0,9167.
        /// </summary>
        /// <param name="start">
        /// Stardate of time period
        /// </param>
        /// <param name="end">
        /// Enddate of time period
        /// </param>
        /// <returns>
        /// Total Years between the two days
        /// </returns>
        public static double DifferenceTotalYears(this DateTime start, DateTime end)
        {
            // Get difference in total months.
            int months = ((end.Year - start.Year) * 12) + (end.Month - start.Month);
            // substract 1 month if end month is not completed
            if (end.Day < start.Day)
            {
                months--;
            }
            double totalyears = months / 12d;
            return totalyears;
        }
