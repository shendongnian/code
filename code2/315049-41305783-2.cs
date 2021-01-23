        #region IDisposable
        private ~MyViewModel()
        {
            Dispose(false);
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        private bool _isDisposed;
        private Dispose(bool disposing)
        {
            if(_isDisposed) return; // prevent double disposing
            // dispose values first, such that they call 
            // the onCompleted() delegate
            MyValue1.Dispose();
            MyValue2.Dispose();
            // dispose all subscriptions at once 
            Subscriptions.Dispose(); 
            // do not suppress finalizer when called from finalizer
            if(disposing) 
            {
                // do not call finalizer when already disposed
                GC.SuppressFinalize(this);
            }
            _isDisposed = true;
        }
        #endregion
    }
