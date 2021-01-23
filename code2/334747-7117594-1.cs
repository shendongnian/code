    public static TResult IfNotNull<T,TResult>(this T obj, Func<T,TResult> func)
    {
        if(obj != null)
        {
            return func(obj);
        }
        return default(TResult);
    }
