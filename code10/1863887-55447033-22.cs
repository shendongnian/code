    public Task<string> PullText()
    {
       try
       {
          // simplified example
          return Task.FromResult("someString");
       }
       catch (Exception e)
       {
          return Task.FromException<string>(e);
       }
    }
