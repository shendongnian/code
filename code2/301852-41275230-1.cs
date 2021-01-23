    public static class StringExtensions
    {
        public static string ReplaceIgnoreCase(this string str, string from, string to)
        {
            return Regex.Replace(str, Regex.Escape(from), to.Replace("$", "$$"), RegexOptions.IgnoreCase);
        }
    }
