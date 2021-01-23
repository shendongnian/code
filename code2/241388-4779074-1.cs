    class LockedAdder<T>
    {
        public object LockObj = new object();
        public IList<T> List;
        public void Add(T x)
        {
            lock (LockObj)
            {
                List.Add(x);
            }
        }
    }
    
    public static Action<T> GetLockedAdd<T>(IList<T> list)
    {
        // This type includes a field for the captured local object,
        // plus another for the IList<T> passed in here.
        var lockedAdder = new LockedAdder<T> { List = list };
        // The lambda becomes a method call on this instance we have
        // just made.
        return new Action<T>(lockedAdder.Add);
    }
