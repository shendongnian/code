    public IEnumerable<KeyValuePair<string, string>> EnumerateDict()
    {
      rwls.EnterWriteLock();
      try
      {
        return dict.List();
      }
      finally
      {
        rwls.ExitWriteLock();
      }
    }
