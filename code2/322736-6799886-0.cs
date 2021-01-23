    public class TestTimer : IDisposable
    {
        private Timer timer;
 
        public TestTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }
 
        #region IDisposable
        // check http://msdn.microsoft.com/en-us/library/ms244737%28v=vs.80%29.aspx
   
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
        ~TestTimer()
        {
            Dispose(false);
        }
        #endregion
    }
