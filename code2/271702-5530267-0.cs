    /// <summary>
        /// Converts the specified DateTime (which should be the UTC time) into the users timezone.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns></returns>
        public static DateTime ToDisplayTime(this DateTime utcDateTime)
        {
            var result = TimeZoneInfo.ConvertTime(utcDateTime, TimeZoneInfo.Local);
            return result;
        }
        /// <summary>
        /// Converts the specified DateTime from local time to UTC
        /// </summary>
        /// <param name="locatDateTime"></param>
        /// <returns></returns>
        public static DateTime FromDisplayTime(this DateTime locatDateTime)
        {
            var result = TimeZoneInfo.ConvertTime(locatDateTime, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById("UTC"));
            return result;
        }
