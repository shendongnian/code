    class DisposableWrapper<T> : where T : IDisposable {
        T _wrapped;
        private bool _disposed;
        public DisposableWrapper(T wrapped) {
            _wrapped = wrapped;
        }
        public T Item {
            get { return _wrapped; }
        }
        public ~DisposableWrapper()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }
        public void Dispose() {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing) {
                _disposed = true;             
                ((IDisposable)_wrapped).Dispose();
                // do extra stuff
            }
        }
    }
