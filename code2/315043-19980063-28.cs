    public static void DisposeSequence<T>(this IEnumerable<T> source)
    {
        foreach (IDisposable disposableObject in source.OfType(System.IDisposable))
        {
            disposableObject.Dispose();
        };
    }
