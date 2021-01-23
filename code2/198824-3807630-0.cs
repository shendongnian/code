    public sealed class SafeHandle<T> : IDisposable where T : IHandleTraits, new() {
        private bool disposed;
        private IntPtr handle_ = IntPtr.Zero;
        private T handleType;
        public SafeHandle() {
            handleType = new T();                        
            handle_ = handleType.Create();
        }
        // etc...
    }
