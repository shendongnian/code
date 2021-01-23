    internal static class Initializer
    {
        private class InitCacheEntry
        {
            private Action<object, object>[] _setters;
            private object[] _values;
            public InitCacheEntry(IEnumerable<Action<object, object>> setters, IEnumerable<object> values)
            {
                _setters = setters.ToArray();
                _values = values.ToArray();
                if (_setters.Length != _values.Length)
                    throw new ArgumentException();
            }
            public void Init(object obj)
            {
                for (int i = 0; i < _setters.Length; i++)
                {
                    _setters[i](obj, _values[i]);
                }
            }
        }
        private static Dictionary<Type, InitCacheEntry> _cache = new Dictionary<Type, InitCacheEntry>();
        private static InitCacheEntry MakeCacheEntry(Type targetType)
        {
            var setters = new List<Action<object, object>>();
            var values = new List<object>();
            foreach (var propertyInfo in targetType.GetProperties())
            {
                var attr = (DefaultAttribute) propertyInfo.GetCustomAttributes(typeof (DefaultAttribute), true).FirstOrDefault();
                if (attr == null) continue;
                var setter = propertyInfo.GetSetMethod();
                if (setter == null) continue;
                // we have to create expression like (target, value) => ((TObj)target).setter((T)value)
                // where T is the type of property and obj is instance being initialized
                var targetParam = Expression.Parameter(typeof (object), "target");
                var valueParam = Expression.Parameter(typeof (object), "value");
                var expr = Expression.Lambda<Action<object, object>>(
                    Expression.Call(Expression.Convert(targetParam, targetType),
                                    setter,
                                    Expression.Convert(valueParam, propertyInfo.PropertyType)),
                    targetParam, valueParam);
                var set = expr.Compile();
                setters.Add(set);
                values.Add(attr.DefaultValue);
            }
            return new InitCacheEntry(setters, values);
        }
        public static void Init(object obj)
        {
            Type targetType = obj.GetType();
            InitCacheEntry init;
            if (!_cache.TryGetValue(targetType, out init))
            {
                init = MakeCacheEntry(targetType);
                _cache[targetType] = init;
            }
            init.Init(obj);
        }
    }
