    public Task<int> DoSomethingAsync(int someValue)
    {
       try
       {
          if (someValue == 1)
             return Task.FromResult(3); // Return a completed task
    
          return MyAsyncMethod(); // Return a task
       }
       catch (Exception e)
       {
          return Task.FromException<int>(e); // Place exception on the task
       }
    }
