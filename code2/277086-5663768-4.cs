    public static class LikeExtension
    {
        public static IEnumerable<T> Like<T>(this IEnumerable<T> source, Func<T, string> selector, string pattern)
        {
            var regex = new Regex(ConvertLikeToRegex(pattern), RegexOptions.IgnoreCase);
            return source.Where(t => IsRegexMatch(selector(t), regex));
        }
    
        static bool IsRegexMatch(string input, Regex regex)
        {
            if (input == null)
                return false;
    
            return regex.IsMatch(input);
        }
    
        static string ConvertLikeToRegex(string pattern)
        {
            StringBuilder builder = new StringBuilder();
            // Turn "off" all regular expression related syntax in the pattern string
            // and add regex begining of and end of line tokens so '%abc' and 'abc%' work as expected
            builder.Append("^").Append(Regex.Escape(pattern)).Append("$");
    
            /* Replace the SQL LIKE wildcard metacharacters with the
            * equivalent regular expression metacharacters. */
            builder.Replace("%", ".*").Replace("_", ".");
    
            /* The previous call to Regex.Escape actually turned off
            * too many metacharacters, i.e. those which are recognized by
            * both the regular expression engine and the SQL LIKE
            * statement ([...] and [^...]). Those metacharacters have
            * to be manually unescaped here. */
            builder.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");
    
            // put SQL LIKE wildcard literals back
            builder.Replace("[.*]", "[%]").Replace("[.]", "[_]");
    
            return builder.ToString();
        }
    }
