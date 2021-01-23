    class RefCounted<T>
    {
        private int refCount;
        public readonly T Obj;
        public RefCounted(T obj)
        {
            Obj = obj;
        }
        public void Get()
        {
            refCount++;
        }
        public void Release()
        {
            if (refCount > 0)
            {
                refCount--;
            }
        }
    }
    class Wrapper<T> : IDisposable
    {
        private RefCounted<T> obj;
        private bool disposed = false;
        public Wrapper(RefCounted<T> o)
        {
            o.Get();
            obj = o;
        }
        public Wrapper<T> Copy()
        {
            return new Wrapper<T>(obj);
        }
        public static implicit operator T(Wrapper<T> wrapper)
        {
            return wrapper.obj.Obj;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    obj.Release();
                    obj = null;
                }
                disposed = true;
            }
        }
    }
    static class Wrapper
    {
        public static Wrapper<T> New<T>(T obj)
        {
            return new Wrapper<T>(new RefCounted<T>(obj));
        }
    }
