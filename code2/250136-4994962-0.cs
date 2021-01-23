    public static TTarget ConvertValue<TTarget>(this object value)
    {
        Type t = typeof(TTarget);
        if (t.IsEnum)
        {
            Delegate del = _delegateCache.GetOrAdd(t, t2 =>
                Delegate.CreateDelegate(typeof(Func<object, TTarget>),
                                        _parseEnumInfo.MakeGenericMethod(t2));
            return ((Func<object, TTarget>)del)(value);
        }
        else //if ...
            return ...;
    }
    private static readonly MethodInfo _parseEnumInfo =
        typeof(YourParentClass).GetMethod("ParseEnum");
    private static readonly ConcurrentDictionary<Type, Delegate> _delegateCache =
        new ConcurrentDictionary<Type, Delegate>();
    public static TEnum ParseEnum<TEnum>(object value)
        where TEnum : struct, IComparable, IConvertible, IFormattable
    {
        // do something
        return ...;
    }
