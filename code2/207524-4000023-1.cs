    static Dictionary<Type, object> NullChecks = new Dictionary<Type, object>();
    public static Func<T, bool> MakeNullCheck<T>()
    {
        object obj;
        Func<T, bool> func;
        if (NullChecks.TryGetValue(typeof(T), out obj))
            return (Func<T, bool>)obj;
        if (typeof(T).IsClass)
            func = x => x != null;
        else if (Nullable.GetUnderlyingType(typeof(T)) != null)
        {
            var param = Expression.Parameter(typeof(T));
            func = Expression.Lambda<Func<T, bool>>(
                Expression.Property(param, typeof(T).GetProperty("HasValue")), param).Compile();
        }
        else
            func = x => false;
        NullChecks[typeof(T)] = func;
        return func;
    }
