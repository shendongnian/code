    static class Coalesce
    {
        static public TResult C<T, TResult>(this T obj, Func<T, TResult> func)
            where TResult : class
        {
            if (obj != null)
                return func(obj);
            return null;
        }
    }
