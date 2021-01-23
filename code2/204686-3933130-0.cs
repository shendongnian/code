    public static string ToTitleCase(this string str, double preserve)
    {
        return string.Join(" ",
            str.Split(' ')
               .Select(s => (s.Count(c => char.IsUpper(c)) / (double)s.Length * 100) > preserve ? char.ToUpper(s[0]) + s.Substring(1).ToLower() : s)
               .ToArray());
    }
