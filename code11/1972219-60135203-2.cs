    string Join<TItem>(
        IEnumerable<TItem> items, Func<TItem, string> itemTextSelecor, string separator)
    {
        var en = items.GetEnumerator();
        if (!en.MoveNext())
            return String.Empty;
        var builder = new StringBuilder();
        if (en.Current != null)
            builder.Append(en.Current);
        while (en.MoveNext())
        {
            builder.Append(separator);
            if (en.Current != null)
                builder.Append(itemTextSelecor(en.Current));
        }
        return builder.ToString();
    }
