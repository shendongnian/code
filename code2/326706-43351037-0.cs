    public static String WildCardToRegular(this String value)
    {
            return "^" + Regex.Escape(value).Replace("\\?", ".").Replace("\\*", ".*") + "$";
    }
    public static bool WildCardMatch(this String value,string pattern,bool ignoreCase = true)
    {
            if (ignoreCase)
                return Regex.IsMatch(value, WildCardToRegular(pattern), RegexOptions.IgnoreCase);
            return Regex.IsMatch(value, WildCardToRegular(pattern));
    }
