    public sealed class WeakReference<T> where T : class
    {
        public WeakReference(T target) : this(target, trackResurrection)
        {}
        public WeakReference(T target, bool trackResurrection)
        {
            refTarget = new WeakReference(target, trackResurrection);
        }
        public T Target { get { return refTarget.Target as T; } }
        public bool IsAlive { get { return refTarget.IsAlive; }}
        private readonly WeakReference refTarget;
    }
