    [AttributeUsage(AttributeTargets.Property)]
    public class RecursivePropertyAttribute
        : Attribute
    {
        private static Dictionary<Type, List<PropertyInfo>> _Cache = new Dictionary<Type, List<PropertyInfo>>();
        public IEnumerable<PropertyInfo> GetRecursiveProperties(Type t)
        {
            // Check the cache for the type
            if (!_Cache.ContainsKey(t))
            { 
                // Create the entry
                _Cache.Add(t, new List<PropertyInfo>());
                
                // Add properties that have the attribute
                foreach (PropertyInfo p in t.GetProperties())
                {
                    object[] attribs = p.GetCustomAttributes(typeof(RecursivePropertyAttribute), true);
                    if (attribs.Length > 0)
                        _Cache[t].Add(p);
                }
            }
            return _Cache[t];
        }
    }
