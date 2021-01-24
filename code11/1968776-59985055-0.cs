    async Task MyMethod()
    {
       try
       {
          var initialResult = await SomeInitialTask();
          var secondResult = await SecondTask(initialResult); // instead of .ContinueWith
          ... etc.
       }
       catch (Exception ex)
       {
          // Much easier than checking .IsFaulted on each nested task
       }
    }  
