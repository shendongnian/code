    IEnumerator<T> enumerator = enumerable.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            T element = enumerator.Current;
            // here goes the body of the loop
        }
    }
    finally
    {
        IDisposable disposable = enumerator as System.IDisposable;
        if (disposable != null) disposable.Dispose();
    }
