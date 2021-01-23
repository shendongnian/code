    public static class RegexExtensions
    {
        public static string GetPattern(this IEnumerable<string> valuesToSearch)
        {
            return string.Format("({0})", string.Join("|", valuesToSearch));
        }
    }
