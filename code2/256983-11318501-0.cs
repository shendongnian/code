    public static void AddOrThrow<T>(this HashSet<T> hash, T item)
    {
        if (!hash.Add(item))
            throw new ValueExistingException();
    }
