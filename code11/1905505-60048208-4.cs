    public async Task<T> FooAsync(/*...*/)
    {
         /*...*/
         using (LogContext.PushProperty("foo", "bar"))
         {
             Log.Information("foobar");
         }
         /*...*/
    }
      
    
