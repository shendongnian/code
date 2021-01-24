    public static void Empty(IEnumerable collection)
    {
        Assert.GuardArgumentNotNull("collection", collection);
        var enumerator = collection.GetEnumerator();
        try
        {
            if (enumerator.MoveNext())
                throw new EmptyException(collection);
        }
        finally
        {
            (enumerator as IDisposable)?.Dispose();
        }
    }
