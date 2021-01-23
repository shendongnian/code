        /// <summary>Converts from a UTC DateTime to the user's local DateTime</summary>
        /// <param name="utcDateTime">UTC DateTime</param>
        /// <param name="timeZoneInfo">The time zone info.</param>
        /// <returns>The DateTime in the user's time zone</returns>
        public static DateTimeOffset UtcToDateTimeOffset(this DateTime utcDateTime, TimeZoneInfo timeZoneInfo = null)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc)
            {
                throw new InvalidTimeZoneException("Converting UTC to Local TimeZone, but was not UTC.");
            }
            DateTimeOffset dto = new DateTimeOffset(utcDateTime, TimeSpan.Zero);
            return timeZoneInfo.IsNotNull() ? dto.ToOffset(timeZoneInfo.GetUtcOffset(dto)) : dto;
        }
