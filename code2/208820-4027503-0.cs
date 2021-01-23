    static class FooExtensions
    {
        public static SomeData WaitOn(this Foo foo, Action<Foo> action)
        {
            SomeData result = null;
            var wait = new AutoResetEvent(false);
    
            foo.Completed += (s, e) =>
            {
                result = e.Data; // I assume this is how you get the data?
                wait.Set();
            };
    
            action(foo);
            if (!wait.WaitOne(5000)) // or whatever would be a good timeout
            {
                throw new TimeoutException();
            }
            return result;
        }
    }
    
    public void TestMethod()
    {
        var foo = new Foo();
        SomeData data = foo.WaitOn(f => f.LongRunningTask());
    }
