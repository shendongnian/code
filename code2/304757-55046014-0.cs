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
            var diff = dayOfWeek - date.DayOfWeek;
            diff += diff <= 0 && exclDate ? 7 : diff < 0 ? 7 : 0;
            return date.AddDays(diff);
        }
    }
