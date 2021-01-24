    List<string>.Enumerator enumerator = SomeClass.Collection.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            string current = enumerator.Current;
        }
    }
    finally
    {
        ((IDisposable)enumerator).Dispose();
    }
