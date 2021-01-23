    public class RefCounted<T> where T : IDisposable
    {
        public RefCounted(T value)
        {
            innerValue = value;
            refCount = 1;
        }
        public void AddRef()
        {
            Interlocked.Increment(ref refCount);
        }
        public void Dispose()
        {
            if(InterlockedDecrement(ref refCount)<=0)
                innerValue.Dispose();
        }
        private int refCount;
        private readonly innerValue;
    }
