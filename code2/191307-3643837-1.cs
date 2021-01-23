    public static string Join(string separator, IEnumerable<string> values)
    {
        if (values == null)
        {
            throw new ArgumentNullException("values");
        }
        if (separator == null)
        {
            separator = Empty;
        }
        using (IEnumerator<string> enumerator = values.GetEnumerator())
        {
            if (!enumerator.MoveNext())
            {
                return Empty;
            }
            StringBuilder builder = new StringBuilder();
            if (enumerator.Current != null)
            {
                builder.Append(enumerator.Current);
            }
            while (enumerator.MoveNext())
            {
                builder.Append(separator);
                if (enumerator.Current != null)
                {
                    builder.Append(enumerator.Current);
                }
            }
            return builder.ToString();
        }
    }
