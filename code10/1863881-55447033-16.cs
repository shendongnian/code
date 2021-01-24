    public Task<string> PullText()
    {
       try
       {
          return Task.Run(() => "hello world");
       }
       catch (Exception e)
       {
          return Task.FromException<string>(e);
       }
    }
