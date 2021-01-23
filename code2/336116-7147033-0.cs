    public static void DisposeIfNecessary(this object obj)
    {
       if (obj != null && obj is IDisposable)
          ((IDisposable)obj).Dispose();
    }
