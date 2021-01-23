    private static IEnumerable<IEnumerable<T>> Split<T>
        (IEnumerable<T> source, ICollection<T> delimiter)
    {
        // window represents the last [delimeter length] elements in the sequence,
        // buffer is the elements waiting to be output when delimiter is hit
        var window = new Queue<T>();
        var buffer = new List<T>();
            
        foreach (T element in source)
        {
            buffer.Add(element);
            window.Enqueue(element);
            if (window.Count > delimiter.Count)
                window.Dequeue();
            if (window.SequenceEqual(delimiter))
            {
                // number of non-delimiter elements in the buffer
                int nElements = buffer.Count - window.Count;
                if (nElements > 0)
                    yield return buffer.Take(nElements).ToArray();
                window.Clear();
                buffer.Clear();
            }
        }
        if (buffer.Any())
            yield return buffer;
    }
