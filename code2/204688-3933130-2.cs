    public static string ToTitleCase(this string str, double preserve)
    {
        return string.Join(" ",
            str.Split(' ')
               .Select(s => s.Length == 0 ? s : char.ToUpper(s[0]) + ((s.Count(c => char.IsUpper(c)) / (double)s.Length * 100) > preserve ? s.Substring(1).ToLower() : s.Substring(1)))
               .ToArray());
    }
