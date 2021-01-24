    string Join<TItem>(
        IEnumerable<TItem> items, Func<TItem, string> itemTextSelecor, string separator)
    {
        var builder = new StringBuilder();
        foreach (var item in items)
        {
            builder.Append(itemTextSelecor(item));
            builder.Append(separator);
        }
        return builder.ToString().TrimEnd(separator.ToCharArray());
    }
