    public Task<string> PullText()
    {
       try
       {
          return Task.FromResult("someString");
       }
       catch (Exception e)
       {
          return Task.FromException<string>(e);
       }
    }
