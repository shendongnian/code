    internal static class ExpressionCache<T>
    {
        private static readonly Dictionary<Expression<Func<T>, Func<T>> Cache = new Dictionary<Expression<Func<T>, Func<T>>();
    
        public static Func<T> CachedCompile(Expression<Func<T>> targetSelector)
        {
            Func<T> cachedFunc;
            if (!Cache.TryGetValue(targetSelector, out cachedFunc))
            {
                cachedFunc = targetSelector.Compile();
                Cache[targetSelector] = cachedFunc;
            }
    
            return cachedFunc;
        }
    }
