    public sealed class WeakReference<T> where T : class
    {
        public WeakReference(T target)
        {
            refTarget = new WeakReference(target);
        }
        public T Target { get { return refTarget.Target as T; } }
        public bool IsAlive { get { return refTarget.IsAlive; }}
        private readonly WeakReference refTarget;
    }
