    public async void DoFoo()
    {
        try
        {
            await Foo();
        }
        catch (ProtocolException ex)
        {
              // The exception will be caught because you've awaited the call in an async method.
        }
    }
   
    //or//
    public void DoFoo()
    {
        try
        {
            Foo().Wait();
        }
        catch (ProtocolException ex)
        {
              /* The exception will be caught because you've awaited the call. */
        }
    } 
