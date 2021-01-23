    class MyDisposable : IDisposable
    {
        private SomethingDisposable foo = new SomethingDisposable();
        
        void IDisposable.Dispose()
        {
            foo.Dispose();
        }
    }
