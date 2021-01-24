    static async Task SomeMethod()
    {
       var task = OperationWithException();
       try
       {
         await task;
       }
       catch (InvalidOperationException)
       {
         // exception is correctly to caught here.
       }
    }
    
    static async Task OperationWithException()
    {
       await Task.Delay(1000);
       // check for it
       throw new InvalidOperationException();
    }
