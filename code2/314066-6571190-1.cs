    private readonly System.Threading.SynchronizationContext _currentContext = System.Threading.SynchronizationContext.Current;
    private readonly object _invokeLocker = new object();
    public object Invoke(Delegate method, object[] args)
    {
        if (method == null)
        {
            throw new ArgumentNullException("method");
        }
        lock (_invokeLocker)
        {
            object objectToGet = null;
            SendOrPostCallback invoker = new SendOrPostCallback(
            delegate(object data)
            {
                objectToGet = method.DynamicInvoke(args);
            });
            _currentContext.Send(new SendOrPostCallback(invoker), method.Target);
            return objectToGet;
         }
    }
