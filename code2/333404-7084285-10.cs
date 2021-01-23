    public static class PropertyReflector
    {
        private static readonly object SyncObj = new object();
        private static readonly Dictionary<Type, List<PropertyInfo>> PropLookup =
            new Dictionary<Type, List<PropertyInfo>>();
        public static IList<PropertyInfo> GetWritableProperties(Type type)
        {
            lock (SyncObj)
            {
                List<PropertyInfo> props;
                if (!PropLookup.TryGetValue(type, out props))
                {
                    var propsOrder = new Dictionary<int, PropertyInfo>();
                    foreach (PropertyInfo p in type.GetProperties())
                    {
                        if (Attribute.IsDefined(p, typeof(WriteableAttribute)))
                        {
                            var attr = (WriteableAttribute)p.GetCustomAttributes(
                                typeof(WriteableAttribute), inherit: true)[0];
                            propsOrder.Add(attr.Order, p);
                        }
                    }
                    props = new List<PropertyInfo>(propsOrder
                        .OrderBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Value));
                    PropLookup.Add(type, props);
                }
                return props;
            }
        }
    }
