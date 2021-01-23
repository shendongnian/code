        elem.Attribute("ID").TryParseInt(-1)
 
        /// <summary>
        /// Parses an attribute to extract an In32 value and falls back to the defaultValue should parsing fail
        /// </summary>
        /// <param name="defaultValue">The value to use should Int32.TryParse fail</param>
        /// <returns>The parsed or default integer value</returns>
        public static int TryParseInt(this XAttribute attr, int defaultValue)
        {
            int result;
            if (!Int32.TryParse((string)attr, out result))
            {
                // When parsing fails, use the fallback value
                result = defaultValue;
            }
            return result;
        }
