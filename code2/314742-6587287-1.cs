    public static class StringExtensions
    {
        public static string FormatThis(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
