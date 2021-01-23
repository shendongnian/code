    try
    {
      Monitor.Enter(_names);
      return _names;
    }
    finally
    {
      Monitor.Exit(_names);
    }
