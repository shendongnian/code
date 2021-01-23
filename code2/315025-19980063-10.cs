    public void DisposeSequence<T>(this IEnumerable<T> source)
    {
        foreach (IDisposable disposableObject in source
                 .Where(source is System.IDisposable)
                 .Select(source as System.IDisposable)
        {
            disposableObject.Dispose();
        };
    }
