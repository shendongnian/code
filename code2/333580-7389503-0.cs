    public sealed class WeakReference<T> : IDisposable
        where T : class
    {
        private volatile IntPtr _handle;
        private GCHandleType _handleType;
        public WeakReference(T target)
            : this(target, false)
        {
        }
        [SecuritySafeCritical]
        public WeakReference(T target, bool trackResurrection)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            _handleType = trackResurrection ? GCHandleType.WeakTrackResurrection : GCHandleType.Weak;
            Target = target;
        }
        [SecuritySafeCritical]
        ~WeakReference()
        {
            Dispose();
        }
        public void Dispose()
        {
            var ptr = _handle;
            if ((ptr != IntPtr.Zero) &&
                Interlocked.CompareExchange(ref _handle, IntPtr.Zero, ptr) == ptr)
            {
                try
                {
                    var handle = GCHandle.FromIntPtr(ptr);
                    if (handle.IsAllocated)
                        handle.Free();
                }
                catch
                { }
            }
            GC.SuppressFinalize(this);
        }
        public bool TryGetTarget(out T target)
        {
            var ptr = _handle;
            if (ptr != IntPtr.Zero)
            {
                try
                {
                    var handle = GCHandle.FromIntPtr(ptr);
                    if (handle.IsAllocated)
                    {
                        target = (T)handle.Target;
                        return !object.ReferenceEquals(target, null);
                    }
                }
                catch
                { }
            }
            target = null;
            return false;
        }
        public bool TryGetTarget(out T target, Func<T> recreator)
        {
            IntPtr ptr = _handle;
            try
            {
                var handle = GCHandle.FromIntPtr(ptr);
                if (handle.IsAllocated)
                {
                    target = (T)handle.Target;
                    if (!object.ReferenceEquals(target, null))
                        return false;
                }
            }
            catch
            { }
            T createdValue = null;
            target = null;
            while ((ptr = _handle) == IntPtr.Zero || object.ReferenceEquals(target, null))
            {
                createdValue = createdValue ?? recreator();
                var newPointer = GCHandle.Alloc(createdValue, _handleType).AddrOfPinnedObject();
                if (Interlocked.CompareExchange(ref _handle, newPointer, ptr) == ptr)
                {
                    target = createdValue;
                    return true;
                }
                else if ((ptr = _handle) != IntPtr.Zero)
                {
                    try
                    {
                        var handle = GCHandle.FromIntPtr(ptr);
                        if (handle.IsAllocated)
                        {
                            target = (T)handle.Target;
                            if (!object.ReferenceEquals(target, null))
                                return false;
                        }
                    }
                    catch
                    { }
                }
            }
            return false;
        }
        public bool IsAlive
        {
            get
            {
                var ptr = _handle;
                return ptr != IntPtr.Zero && GCHandle.FromIntPtr(ptr).IsAllocated;
            }
        }
        public T Target
        {
            get
            {
                T target;
                TryGetTarget(out target);
                return target;
            }
            set
            {
                Dispose();
                _handle = GCHandle.Alloc(value, _handleType).AddrOfPinnedObject();
                GC.ReRegisterForFinalize(this);
            }
        }
    }
