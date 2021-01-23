        /// <summary>
        /// Converts a Unix timestamp into a System.DateTime
        /// </summary>
        /// <param name="timestamp">The Unix timestamp in milliseconds to convert, as a double</param>
        /// <returns>DateTime obtained through conversion</returns>
        public static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp / 1000); // convert from milliseconds to seconds
        }
