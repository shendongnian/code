    class DisposableWithFinalizer : IDisposable
    {
        Stream _stream;
        IntPtr _handle;
        private bool _disposed;
        public DisposableWithFinalizer()
        {
            _stream = File.OpenRead(@"c:\test\test.txt");
            _handle = new IntPtr();
        }
        public long FileLength()
        {
            if (_disposed) throw new ObjectDisposedException("MyObject");
            return _stream.Length;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources
                    if (_stream != null) _stream.Dispose();
                }
                // Dispose unmanaged resources
                _handle = IntPtr.Zero;
                _stream = null;
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~DisposableWithFinalizer()
        {
            Dispose(false);
        }
    }
