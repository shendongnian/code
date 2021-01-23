    public class TestTimer : IDisposable
    {
        private Timer timer;
        public TestTimer()
        {
            timer = new Timer(1000);
            ...
        }
 
        #region IDisposable
   
        public void Dispose()
        {
            Dispose(true);
        }
        volatile bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && !disposed)  
            {
                timer.Dispose();
                GC.SupressFinalize(this);
                disposed = true;
            }
        }
        ~TestTimer() { Dispose(false); }
        #endregion
    }
