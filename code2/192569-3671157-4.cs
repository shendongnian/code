    public static class StringExtensions
    {
        public static IEnumerable<char> RemoveChars(this IEnumerable<char> originalString,
            params char[] removingChars)
        {
            return originalString.Except(removingChars);
        }
    }
