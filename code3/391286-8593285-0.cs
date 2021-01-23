        public static TResult IfNotNull<T, TResult>(this T obj, Func<T, TResult> selector)
            where T : class
        {
            return obj.IfNotNull(selector, default(TResult));
        }
        public static TResult IfNotNull<T, TResult>(this T obj, Func<T, TResult> selector, TResult valueIfNull)
            where T : class
        {
            if (obj == null)
                return valueIfNull;
            return selector(obj);
        }
    ...
        var e = get(y).IfNotNull(_ => _.Title);
