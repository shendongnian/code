    public static string RemoveRepeatedSpaces(this string s)
    {
        return s[0] + string.Join("",
               s.Zip(
                   s.Skip(1),
                   (x, y) => x == y && y == ' ' ? (char?)null : y));
    }
