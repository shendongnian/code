    ///<summary>
    /// Extension methods for DateTime class
    ///</summary>
    public static class DateTimeExt
    {
        /// <summary>
        /// <para>Truncates a DateTime to a specified resolution.</para>
        /// <para>A convenient source for resolution is TimeSpan.TicksPerXXXX constants.</para>
        /// </summary>
        /// <param name="date">The DateTime object to truncate</param>
        /// <param name="resolution">e.g. to round to nearest second, TimeSpan.TicksPerSecond</param>
        /// <returns>Truncated DateTime</returns>
        public static System.DateTime Truncate(this System.DateTime date, long resolution)
        {
            return new System.DateTime(date.Ticks - (date.Ticks % resolution), date.Kind);
        }
    }
    
