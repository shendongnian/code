    public static bool TryInvoke<T>(this Delegate del, T arg)
    {
        var action = del as Action<T>();
        if (action != null)
        {
            action(arg);
            return true;
        }
        return false;
    }
    public static bool TryFunc<T, TResult>(this Delegate del, T arg, out TResult result)
    {
        result = default(TResult);
        var func = del as Func<T, TResult>();
        if (func != null)
        {
            result = func(arg);
            return true;
        }
        return false;
    }
