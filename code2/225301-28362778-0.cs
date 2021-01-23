    public static string RemoveSpecialCharacters(string input)
    {    
        Regex r = new Regex(
                      "(?:[^a-zA-Z0-9 ]|(?<=['\"])s)",
                      RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        return r.Replace(input, String.Empty);    
    }
