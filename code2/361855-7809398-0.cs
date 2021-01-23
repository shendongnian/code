    public event Action<TProperty> MyEvent;
    public TProperty Prop { get; private set; }
    bool WaitUntilPropertyIs(int timeout, IEnumerable<TProperty> allowedValues)
    {
        var gotAllowed = new ManualResetEventSlim(false);
        Action<int> handler = item =>
        {
            if (allowedValues.Contains(item)) gotAllowed.Set();
        };
    
        try
        {
            MyEvent += handler;
            return allowedValues.Contains(Prop) || gotAllowed.Wait(timeout);
        }
        finally
        {
            MyEvent -= handler;
        }
    }
