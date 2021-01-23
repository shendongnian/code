    internal static class TryConvert
    {
        /// <summary>
        /// Returns the integer result of parsing a string, or null.
        /// </summary>
        internal static int? ToNullableInt32(string toParse)
        {
            int result;
            if (Int32.TryParse(toParse, out result)) return result;
            return null;
        }
    
        /// <summary>
        /// Returns the integer result of parsing a string,
        /// or the supplied failure value if the parse fails.
        /// </summary>
        internal static int ToInt32(string toParse, int toReturnOnFailure)
        {
            // The nullable-result method sets up for a coalesce operator.
            return ToNullableInt32(toParse) ?? toReturnOnFailure;
        }
    }
    
    internal static class CallingCode
    {
        internal static void Example(string someString)
        {
            // Name your poison. :-)
            int i = TryConvert.ToInt32(someString, -1);
            int j = TryConvert.ToNullableInt32(someString) ?? -1;
            // This avoids the issue of a sentinel value.
            int? k = TryConvert.ToNullableInt32(someString);
            if (k.HasValue)
            {
                // do something
            }
        }
    }
