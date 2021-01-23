    public void DoStuff<T>(T obj)
    {
        if ((obj is IComparable) && (obj is ICloneable))
        {
            Type t = typeof(T);
            Delegate del = _delegateCache.GetOrAdd(t, t2 =>
                Delegate.CreateDelegate(typeof(Action<T>),
                                        _doSpecialStuffInfo.MakeGenericMethod(t2));
            ((Action<T>)del)(obj);
        }
    }
    private static readonly MethodInfo _doSpecialStuffInfo =
        typeof(YourParentClass).GetMethod("DoSpecialStuff");
    private static readonly ConcurrentDictionary<Type, Delegate> _delegateCache =
        new ConcurrentDictionary<Type, Delegate>();
    public void DoSpecialStuff<T>(T obj)
        where T : IComparable, ICloneable
    {
    }
