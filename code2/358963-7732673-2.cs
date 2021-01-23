        public class ServiceCache
        {
            private readonly Dictionary<string, CachedCallInfo> _services =
                new Dictionary<string, CachedCallInfo>();
            public void RegisterService(string name, Func<object[], object> method)
            {
                _services[name] = new CachedCallInfo(method);
            }
            // "params" keyword is used to simplify method calls
            public T GetResult<T>(string serviceName, params object[] parameters)
            {
                return _services[serviceName].GetResult<T>(parameters);
            }
        }
    
    
