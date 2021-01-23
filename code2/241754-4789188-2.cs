    using System.Runtime.InteropServices;
    [Serializable]
    public class AltDataKey<T>
    {
        private long id;  // IntPtr is either 32- or 64-bit, so to be safe store as a long.
        public AltDataKey(...)
        {
            var handle = GCHandle.Alloc(this);
            var ptr = GCHandle.ToIntPtr(handle);
            id = (long)ptr;
            handle.Free();
        }
        // as above
    }
