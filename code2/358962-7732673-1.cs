        // contains cached results for a single service
        class CachedCallInfo
        {
            private readonly Func<object[], object> _method;
            private readonly Dictionary<Parameters, object> _cache
                = new Dictionary<Parameters, object>();
            public CachedCallInfo(Func<object[], object> method)
            {
                _method = method;
            }
            public T GetResult<T>(params object[] parameters)
            {
                // use out Parameters class to ensure comparison
                // by value
                var key = new Parameters(parameters);
                object result = null;
                // result exists?
                if (!_cache.TryGetValue(key, out result))
                {
                    // do the actual service call
                    result = _method(parameters);
                    // add to cache
                    _cache.Add(key, result);
                }
                return (T)result;
            }
        }
    
