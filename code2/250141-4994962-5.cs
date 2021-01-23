    public void DoStuff<T>(T obj)
    {
        if ((obj is IComparable) && (obj is ICloneable))
        {
            Delegate del = _delegateCache.GetOrAdd(typeof(T), t =>
                Delegate.CreateDelegate(typeof(Action<T>),
                                        this,
                                        _doSpecialStuffInfo.MakeGenericMethod(t));
            ((Action<T>)del)(obj);
        }
    }
    private static readonly MethodInfo _doSpecialStuffInfo =
        typeof(YourParentClass).GetMethod("DoSpecialStuff");
    private readonly ConcurrentDictionary<Type, Delegate> _delegateCache =
        new ConcurrentDictionary<Type, Delegate>();
    public void DoSpecialStuff<T>(T obj)
        where T : IComparable, ICloneable
    {
    }
