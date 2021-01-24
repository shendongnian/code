    public static string Delimit(this string s, int size)
    {
        string[] split = Regex.Split(input, @$"\d{size}");
        return delimited = string.Join(",", split);
    }
