    public static class Utility
    {
        public static string RemoveWhitespaces(this string input)
        {
            return string.Join(string.Empty, input.Where(c => !char.IsWhiteSpace(c)));
        }
    }
