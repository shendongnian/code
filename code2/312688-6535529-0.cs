    public static class MyExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return false;
            return string.IsNullOrEmpty(value.Trim());
        }
    }
