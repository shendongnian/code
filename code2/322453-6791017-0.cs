    public static bool IsNullOrEmpty(this IEnumerable value)
    {
        if (value == null)
        {
            return true;
        }
        var iterator = value.GetEnumerator();
        try
        {
            return !iterator.MoveNext();
        }
        finally
        {
            // Non-generic IEnumerator doesn't extend IDisposable
            IDisposable disposable = iterator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
