    public static class DateTimeExtensions
    {
        /// <summary>
        /// Gets the next date.
        /// </summary>
        /// <param name="date">The date to inspected.</param>
        /// <param name="dayOfWeek">The day of week you want to get.</param>
        /// <param name="exclDate">if set to <c>true</c> the current date will be excluded and include next occurrence.</param>
        /// <returns></returns>
        public static DateTime GetNextDate(this DateTime date, DayOfWeek dayOfWeek, bool exclDate = true)
        {
            //note: first we need to check if the date wants to move back by date - Today, + diff might move it forward or backwards to Today
            //eg: date - Today = 0 - 1 = -1, so have to move it forward
            var diff = dayOfWeek - date.DayOfWeek;
            var ddiff = date.Date.Subtract(DateTime.Today).Days + diff;
            //note: ddiff < 0 : date calculates to past, so move forward, even if the date is really old, it will just move 7 days from date passed in
            //note: ddiff >= (exclDate ? 6 : 7) && diff < 0 : date is into the future, so calculated future weekday, based on date
            if (ddiff < 0 || ddiff >= (exclDate ? 6 : 7) && diff < 0)
                diff += 7; 
            //note: now we can get safe values between 0 - 6, especially if past dates is being used
            diff = diff % 7;
            
            //note: if diff is 0 and we are excluding the date passed, we will add 7 days, eg: 1 week
            diff += diff == 0 & exclDate ? 7 : 0;
            return date.AddDays(diff);
        }
    }
