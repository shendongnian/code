    public static string Repeat(this string str, int count)
    {
        return Enumerable.Repeat(str, count)
                         .Aggregate(
                            new StringBuilder(),
                            (sb, s) => sb.Append(s))
                         .ToString();
    }
