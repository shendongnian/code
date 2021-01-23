    public static IEnumerable<T> AsOrEmpty(this object value)
    {
        T t = value as T;
        if (t != null)
        {
            yield return t;
        }
    }
