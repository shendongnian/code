    class Program
    {
        public static void Main()
        {
            using (TestDisposable d = new TestDisposable())
            {
            } // Will trace "disposed"
            UseDisposable use = UseDisposable.Create(new TestDisposable());
            // Will trace "disposed"
        }
    }
    public class UseDisposable
    {
        public TestDisposable Disposable;
        public static UseDisposable Create(TestDisposable disposable)
        {
            return new UseDisposable()
                {
                    Disposable = disposable
                };
        }
    }
    public class TestDisposable : IDisposable
    {
        private bool _disposed = false;
        #region IDisposable Membres
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if(!_disposed && disposing)
            {
                Trace.WriteLine("Disposed");
                _disposed = true;
            }
        }
        #endregion
    }
