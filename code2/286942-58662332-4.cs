    public static Tuple<WeakReference, ManualResetEvent, int> GetKillableWr(Func<object> func, bool useGetHashCode = false)
    {
        var foo = func();
        var result = new Tuple<WeakReference, ManualResetEvent, int>(new WeakReference(foo), new ManualResetEvent(false), useGetHashCode ? (foo?.GetHashCode() ?? 0) : RuntimeHelpers.GetHashCode(foo));
    
        Task.Factory.StartNew(() =>
        {
            result.Item2.WaitOne();
            GC.KeepAlive(foo);  // need this here to make sure it doesn't get GC-ed ahead of time
            foo = null;
        });
    
        return result;
    }
