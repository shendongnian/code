    public static IEnumerable<TSource> WhereLike<TSource>(this IEnumerable<TSource> source, Func<TSource, string> selector, string match)
        {
            /* Turn "off" all regular expression related syntax in
                * the pattern string. */
            string pattern = Regex.Escape(match);
    
            /* Replace the SQL LIKE wildcard metacharacters with the
            * equivalent regular expression metacharacters. */
            pattern = pattern.Replace("%", ".*?").Replace("_", ".");
    
            /* The previous call to Regex.Escape actually turned off
            * too many metacharacters, i.e. those which are recognized by
            * both the regular expression engine and the SQL LIKE
            * statement ([...] and [^...]). Those metacharacters have
            * to be manually unescaped here. */
            pattern = pattern.Replace(@"\[", "[").Replace(@"\]", "]").Replace(@"\^", "^");
            Regex reg = new Regex(pattern, RegexOptions.IgnoreCase);
    
            return source.Where(t => reg.IsMatch(selector(t)));
        }
