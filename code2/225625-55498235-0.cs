    static class StringExtensions
    {
        public static string ToLowerFirst(this string text)
            => !string.IsNullOrEmpty(text)
                ? $"{text.Substring(0, 1).ToLower()}{text.Substring(1)}"
                : text;
    }
