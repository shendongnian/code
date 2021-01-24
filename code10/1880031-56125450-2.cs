    public Task<int> DoSomethingAsync(int someValue)
    {
       try
       {
          if (someValue == 1)
             return Task.FromResult(3); // return a completed task
    
          return MyAsyncMethod(); // return a task
       }
       catch (Exception e)
       {
          return Task.FromException<int>(e); // place exception on the task
       }
    }
