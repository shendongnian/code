        /// <summary>
        /// Returns the input string with the first character converted to uppercase if a letter
        /// </summary>
        /// <remarks>Null input returns null</remarks>
        public static string FirstLetterToUpperCase(this string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;
            return char.ToUpper(s[0]) + s.Substring(1);
        }
