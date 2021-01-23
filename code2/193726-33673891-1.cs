    public static IEnumerable<T> Use<T>(this T obj) where T : IDisposable
    {
        try
        {
            yield return obj;
        }
        finally
        {
            if (obj != null)
                obj.Dispose();
        }
    }
