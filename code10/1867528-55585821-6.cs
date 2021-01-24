    public Task<bool> DoSomeInterfaceAsync()
    {
       try
       {
          // return a completed task
          return Task.FromResult(DoSomethingThatMightThrow());
       }
       catch (Exception e)
       {
          // Add the exception to the task 
          return Task.FromException<bool>(e);
       }   
    }
