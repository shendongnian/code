    /// <summary>
    /// Extensions for the <see cref="DateTime"/> class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Provides the same functionality as the ToShortDateString() method, but
        /// with leading zeros.
        /// <example>
        /// ToShortDateString: 5/4/2011 |
        /// ToShortDateStringZero: 05/04/2011
        /// </example>
        /// </summary>
        /// <param name="source">Source date.</param>
        /// <returns>Culture safe short date string with leading zeros.</returns>
        public static string ToShortDateStringZero(this DateTime source)
        {
            return ToShortStringZero(source,
                CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern,
                CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator);
        }
    
        /// <summary>
        /// Provides the same functionality as the ToShortTimeString() method, but
        /// with leading zeros.
        /// <example>
        /// ToShortTimeString: 2:06 PM |
        /// ToShortTimeStringZero: 02:06 PM
        /// </example>
        /// </summary>
        /// <param name="source">Source date.</param>
        /// <returns>Culture safe short time string with leading zeros.</returns>
        public static string ToShortTimeStringZero(this DateTime source)
        {
            return ToShortStringZero(source,
                CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern,
                CultureInfo.CurrentCulture.DateTimeFormat.TimeSeparator);
        }
    
        private static string ToShortStringZero(this DateTime source, 
            string pattern,
            string seperator)
        {
            var format = pattern.Split(new[] {seperator}, StringSplitOptions.None);
    
            var newPattern = string.Empty;
    
            for (var i = 0; i < format.Length; i++)
            {
                newPattern = newPattern + format[i];
                if (format[i].Length == 1)
                    newPattern += format[i];
                if (i != format.Length - 1)
                    newPattern += seperator;
            }
    
            return source.ToString(newPattern, CultureInfo.InvariantCulture);
        }
    }
