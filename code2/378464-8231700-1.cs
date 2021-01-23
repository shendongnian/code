    sealed class MyClass : IDisposable
    {
        SomeHelper helper = CreateHelper();
    
        // ...foo and bar that now just use the class helper....
    
        //~MyClass()
        public void Dispose()    
        {
          helper.Dispose();
        }                         
    }
