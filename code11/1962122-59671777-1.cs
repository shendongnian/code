    public static string Delimit(this string s, int size)
    {
        MatchCollection split = Regex.Matches(input, @$"\d{{size}}");
        return delimited = string.Join(",", split);
    }
