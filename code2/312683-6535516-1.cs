    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return false;
            return string.IsNullOrEmpty(value.Trim());
        }
    }
