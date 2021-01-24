    public Task<string> PullText()
    {
       try
       {
          return Task.Run(() => DoCpuWork());
       }
       catch (Exception e)
       {
          return Task.FromException<string>(e);
       }
    }
