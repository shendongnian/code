    public static class StringExtensions
    {
        public static IEnumerable<char> RemoveChar(this IEnumerable<char> originalString, char removingChar)
        {
            return originalString.Where(@char => @char != removingChar);
        }
    }
