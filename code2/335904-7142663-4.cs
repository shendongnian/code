    public class ExchangeDataDispatcher :
       IDisposable
    {
        public ExchangeDataDispatcher(ExchangeCommonDataSource parDataSource)
        {
            myDataSource = parDataSource;
            myDataSource.HandleDataReceived += 
                new EventHandler(HandleDataReceived);
            DispatcherInitialization();
        }
        private ExchangeCommonDataSource myDataSource;
        private void HandleDataReceived(object sender, e EventArgs)
        {
            // here you could record statistics or whatever about the data
            DispatcherHandleDataReceived(EventArgs);
        }
        
        protected abstract void  DispatcherHandleDataReceived(e EventArgs);
        protected abstract void DispatcherShutdown();
        // significantly ripped from Microsoft's page on IDisposable
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if(disposing)
                {
                    // call a function which can be overridden in derived
                    // classes
                    DispatcherShutdown();
                }
                // Note disposing has been done.
                disposed = true;
            }
        }        
    }
