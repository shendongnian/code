    public IEnumerable<KeyValuePair<string, string>> EnumerateDict()
    {
      rwls.EnterWriteLock();
      try
      {
        return dict.ToList();
      }
      finally
      {
        rwls.ExitWriteLock();
      }
    }
