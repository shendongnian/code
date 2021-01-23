    string trimmed = input.NullSafeTrim();
    // ...
    public static class StringExtensions
    {
        public static string NullSafeTrim(this string source)
        {
            if (source == null)
                return source;    // or return an empty string if you prefer
            return source.Trim();
        }
    }
