    public static string Join<T>(this IEnumerable<T> list,
                                 string joiner,
                                 string lastJoiner = null)
    {
        StringBuilder sb = new StringBuilder();
        string sep = null, lastItem = null;
        foreach (T item in list)
        {
            if (lastItem != null)
            {
                sb.Append(sep);
                sb.Append(lastItem);
                sep = joiner;
            }
            lastItem = item.ToString();
        }
        if (lastItem != null)
        {
            if (sep != null)
                sb.Append(lastJoiner ?? joiner);
            sb.Append(lastItem);
        }
        return sb.ToString();
    }
    Console.WriteLine(people.Select(x => x.ID + ":" + x.Name).Join(", ", " and "));
