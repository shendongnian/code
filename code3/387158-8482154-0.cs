    public static void AddToDict(string key, string value)
    {
      rwls.EnterReadLock();
      try
      {
        dict[key] = value;
      }
      finally
      {
        rwls.ExitReadLock();
      }
    }
    public static bool ReadFromDict(string key, out string value)
    {
      rwls.EnterReadLock();
      try
      {
        return dict.TryGetValue(key, out value);
      }
      finally
      {
        rwls.ExitReadLock();
      }
    }
