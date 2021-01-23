    public static class Extensions
    {
        public static bool CaseInsensitiveContains(this string source, string value)
        {
            return source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
