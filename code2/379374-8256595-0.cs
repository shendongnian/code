    public sealed class ToBase64Transform : ICryptoTransform
    {
        private bool disposed;
    
        public void Dispose()
        {
            if (disposed) return;
            // Dispose managed objects
            disposed = true;
        }
