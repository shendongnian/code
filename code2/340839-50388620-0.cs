    using System.Text;
    /// <summary>
    /// Provides extension methods for string.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Replaces all occurences of any of the given characters with the new string value.
        /// </summary>
        /// <param name="original">The original input string.</param>
        /// <param name="charsToBeReplaced">The characters to be replaced.</param>
        /// <param name="newStringValue">The new replacement string.</param>
        /// <returns>A string that is equivalent to the current string except that
        /// all instances of the old characters are replaced with the given new string value.
        /// If none of these characters are found, the method returns the original string.
        /// </returns>
        public static string ReplaceAll(this string original, string charsToBeReplaced, string newStringValue)
        {
            if (string.IsNullOrEmpty(original)) return original;
            if (charsToBeReplaced == null || charsToBeReplaced.Length <= 0) return original;
            if (newStringValue == null) newStringValue = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (char ch in original)
            {
                if (charsToBeReplaced.IndexOf(ch) >= 0) sb.Append(newStringValue);
                else sb.Append(ch);
            }
            return sb.ToString();
        }
    }
