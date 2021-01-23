    private static IEnumerable<IEnumerable<T>> Split<T>
        (IEnumerable<T> source, ICollection<T> delimiter)
    {
        // window represents the last [delimeter length] elements in the sequence,
        // buffer is the elements waiting to be output when delimiter is hit
        var window = new LinkedList<T>();
        var buffer = new List<T>();
    
        using (var e = source.GetEnumerator())
        {
            while (e.MoveNext())
            {
                buffer.Add(e.Current);    
                window.AddLast(e.Current);
                if (window.Count > delimiter.Count)
                    window.RemoveFirst();
    
                if (window.SequenceEqual(delimiter))
                {
                    // if we have non-delimiter elements in the buffer
                    if (buffer.Count > window.Count)
                        yield return buffer.Take(buffer.Count - window.Count);
    
                    window.Clear();
                    buffer.Clear();
                }
            }
        }
    
        if (buffer.Any())
            yield return buffer;
    }
