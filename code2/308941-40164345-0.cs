        /// <summary>
        /// Removes extra white space.
        /// </summary>
        /// <param name="s">
        /// The string
        /// </param>
        /// <returns>
        /// The string, with only single white-space groupings. 
        /// </returns>
        public static string RemoveExtraWhiteSpace(this string s)
        {
            if (s.Length == 0)
            {
                return string.Empty;
            }
            var stringBuilder = new StringBuilder();
            var whiteSpaceCount = 0;
            foreach (var character in s)
            {
                if (char.IsWhiteSpace(character))
                {
                    whiteSpaceCount++;
                }
                else
                {
                    whiteSpaceCount = 0;
                }
                if (whiteSpaceCount > 1)
                {
                    continue;
                }
                stringBuilder.Append(character);
            }
            return stringBuilder.ToString();
        }
