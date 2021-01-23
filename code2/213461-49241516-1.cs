    public static class StringExtensions
    {
        public static string FirstLetterToUpper(this string input)
        {
            return String.Concat(input.Select((currentChar, index) => index == 0 ? Char.ToUpper(currentChar) : currentChar));
        }
    }
