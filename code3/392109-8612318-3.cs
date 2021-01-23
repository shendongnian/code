    public class Foo
    {
        private static readonly HashSet<WeakReference> _trackedFoos = new HashSet<WeakReference>();
        private static readonly object _foosLocker = new object();
        private readonly WeakReference _weakReferenceToThis;
        public static void DoForAllFoos(Action<Foo> action)
        {
            if (action == null)
                throw new ArgumentNullException("action");
            lock (_foosLocker)
            {
                foreach (var foo in _trackedFoos.Select(w => w.Target).OfType<Foo>())
                    action(foo);
            }
        }
        public Foo()
        {
           _weakReferenceToThis = new WeakReference(this);
            lock (_foosLocker)
            {
                _trackedFoos.Add(_weakReferenceToThis);
            }
        }
        ~Foo()
        {
            lock (_foosLocker)
            {
                _trackedFoos.Remove(_weakReferenceToThis);
            }
        }
    }
