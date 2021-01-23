    /// <summary>
    /// Turns all elements in the enumerable to strings and joins them using the
    /// specified string as the separator and the specified prefix and suffix for
    /// each string.
    /// <example>
    ///   <code>
    ///     var a = (new[] { "Paris", "London", "Tokyo" }).Join("[", "]", ", ");
    ///     // a contains "[Paris], [London], [Tokyo]"
    ///   </code>
    /// </example>
    /// </summary>
    public static string JoinString<T>(this IEnumerable<T> values,
        string separator = null, string prefix = null, string suffix = null)
    {
        if (values == null)
            throw new ArgumentNullException("values");
        var enumerator = values.GetEnumerator();
        if (!enumerator.MoveNext())
            return "";
        StringBuilder sb = new StringBuilder();
        if (prefix != null)
            sb.Append(prefix);
        sb.Append(enumerator.Current.ToString());
        if (suffix != null)
            sb.Append(suffix);
        while (enumerator.MoveNext())
        {
            if (separator != null)
                sb.Append(separator);
            if (prefix != null)
                sb.Append(prefix);
            sb.Append(enumerator.Current.ToString());
            if (suffix != null)
                sb.Append(suffix);
        }
        return sb.ToString();
    }
