    class MyClass : IDisposable
    {
        readonly SomeHelper helper = CreateHelper();
    
        // any method can use helper
    
        public void Dispose()
        {
           helper.Dispose();
        }
    }
