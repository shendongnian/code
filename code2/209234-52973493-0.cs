    public static class LazyCachableGetter
    {
        private static ConditionalWeakTable<object, IDictionary<string, object>> Instances = new ConditionalWeakTable<object, IDictionary<string, object>>();
        public static R LazyValue<T, R>(this T obj, Func<R> factory, [CallerMemberName] string prop = "")
        {
            R result = default(R);
            if (!ReferenceEquals(obj, null))
            {
                if (!Instances.TryGetValue(obj, out var cache))
                {
                    cache = new ConcurrentDictionary<string, object>();
                    Instances.Add(obj, cache);
                }
                if (!cache.TryGetValue(prop, out var cached))
                {
                    cache[prop] = (result = factory());
                }
                else
                {
                    result = (R)cached;
                }
            }
            return result;
        }
    }
