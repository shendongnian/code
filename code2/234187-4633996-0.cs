    public IPlugin GetPlugin(string key)
    {
      mutex.WaitOne();
      
      try
      {
        var plugin = plugins
          .Where(l => l.Metadata["key"] == key)
          .Select(l => l.Value);
          
        return plugin;
      }
      finally
      {
        mutex.ReleaseMutex();
      }
    }
