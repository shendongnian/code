    public static class StringExtensions
    {
        public static string FirstLetterToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;
            return String.Concat(input.Select((currentChar, index) => index == 0 ? Char.ToUpper(currentChar) : currentChar));
        }
    }
