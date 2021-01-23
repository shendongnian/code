        /// <summary>
        /// Returns the input string with the first character converted to uppercase, mutates any nulls passed into string.Empty
        /// </summary>
        public static string FirstLetterToUpperCaseAndConvertNullToEmptyString(this string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
