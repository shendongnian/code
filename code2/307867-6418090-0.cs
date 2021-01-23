    public enum SequenceSplitOptions { None, RemoveEmptyEntries }
    public static IEnumerable<IList<T>> SequenceSplit<T>(
        this IEnumerable<T> source,
        IEnumerable<T> separator)
    {
        return SequenceSplit(source, separator, SequenceSplitOptions.None);
    }
    public static IEnumerable<IList<T>> SequenceSplit<T>(
        this IEnumerable<T> source,
        IEnumerable<T> separator,
        SequenceSplitOptions options)
    {
        if (source == null)
            throw new ArgumentNullException("source");
        if (options != SequenceSplitOptions.None
         && options != SequenceSplitOptions.RemoveEmptyEntries)
            throw new ArgumentException("Illegal option: " + (int)option);
        if (separator == null)
        {
            yield return source.ToList();
            yield break;
        }
        var sep = separator as IList<T> ?? separator.ToList();
        if (sep.Count == 0)
        {
            yield return source.ToList();
            yield break;
        }
        var buffer = new List<T>();
        var candidate = new List<T>(sep.Count);
        var sindex = 0;
        foreach (var item in source)
        {
            candidate.Add(item);
            if (!item.Equals(sep[sindex]))
            {   // item is not part of the delimiter
                buffer.AddRange(candidate);
                candidate.Clear();
                sindex = 0;
            }
            else if (++sindex >= sep.Count)
            {   // candidate is the delimiter
                if (options == SequenceSplitOptions.None || buffer.Count > 0)
                    yield return buffer.ToList();
                buffer.Clear();
                candidate.Clear();
                sindex = 0;
            }
        }
        if (buffer.Count > 0)
            yield return buffer;
    }
