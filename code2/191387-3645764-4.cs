    /// <summary>
    /// Turns all elements in the enumerable to strings and joins them using the
    /// specified string as the separator and the specified prefix and suffix for
    /// each string.
    /// <example>
    ///   <code>
    ///     var a = (new[] { "Paris", "London", "Tokyo" }).JoinString(", ", "[", "]");
    ///     // a contains "[Paris], [London], [Tokyo]"
    ///   </code>
    /// </example>
    /// </summary>
    public static string JoinString<T>(this IEnumerable<T> values,
        string separator = null, string prefix = null, string suffix = null)
    {
        if (values == null)
            throw new ArgumentNullException("values");
        using (var enumerator = values.GetEnumerator())
        {
            if (!enumerator.MoveNext())
                return "";
            StringBuilder sb = new StringBuilder();
            sb.Append(prefix).Append(enumerator.Current.ToString()).Append(suffix);
            while (enumerator.MoveNext())
                sb.Append(separator).Append(prefix)
                  .Append(enumerator.Current.ToString()).Append(suffix);
            return sb.ToString();
        }
    }
