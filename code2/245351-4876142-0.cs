    public static bool Like(this string value, string term)
        {
            Regex regex = new Regex(string.Format("^{0}$", term.Replace("*", ".*")), RegexOptions.IgnoreCase);
            return regex.IsMatch(value ?? string.Empty);
        }
        public static IEnumerable<string> Like(this IEnumerable<string> source, string expression)
        {
            return (from s in source where s.Like(expression) select s);
        }
