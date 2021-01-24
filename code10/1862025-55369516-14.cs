    public async void DoSomethingFireAndForget()
    {
       try
       {
          await DoSomethingAsync();
       }
       catch (Exception e)
       {
          // Deal with unobserved exceptions 
          // or the will be dragons
       }  
    }
