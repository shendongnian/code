    class LockedAdder<T>
    {
        // This field serves the role of the lockObj variable; it will be
        // initialized when the type is instantiated.
        public object LockObj = new object();
        // This field serves as the list parameter; it will be set within
        // the method.
        public IList<T> List;
        // This is the method for the lambda.
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
        // Initializing the lockObj variable becomes equivalent to
        // instantiating the generated class.
        var lockedAdder = new LockedAdder<T> { List = list };
        // The lambda becomes a method call on the instance we have
        // just made.
        return new Action<T>(lockedAdder.Add);
    }
