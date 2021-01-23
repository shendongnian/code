      /// <summary>
        /// Put a string between double quotes.
        /// </summary>
        /// <param name="value">Value to be put between double quotes ex: foo</param>
        /// <returns>double quoted string ex: "foo"</returns>
        public static string PutIntoQuotes(this string value)
        {
            return "\"" + value + "\"";
        }
