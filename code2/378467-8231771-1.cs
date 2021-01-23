    class MyClass : IDisposable
    {
        readonly SomeHelper helper = CreateHelper();
    
        // any method can use helper
    
        public void Dispose()
        {
           helper.Dispose();
        }
    }
    using(var myObj = new MyClass()) {
        // at the end, myObj.Dispose() will trigger helper.Dispose()
    }
