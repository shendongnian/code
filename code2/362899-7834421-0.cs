    public bool SqlWildcardMatch(string input, string sqlLikePattern)
    {
         sqlLikePattern = Regex.Replace(sqlLikePattern, "^([^%])", "^$1");
         sqlLikePattern = Regex.Replace(sqlLikePattern, "([^%])$", "$1$$");
         return Regex.IsMatch(input, string.Replace(sqlLikePattern, "%", ".*"));
    }
