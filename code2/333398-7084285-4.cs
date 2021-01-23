    public abstract class Foo
    {
        private static readonly object SyncObj = new object();
        private static readonly Dictionary<Type, List<PropertyInfo>> PropLookup =
            new Dictionary<Type, List<PropertyInfo>>();
        private IList<PropertyInfo> GetWritableProperties(Type type)
        {
            lock (SyncObj)
            {
                List<PropertyInfo> props;
                if (!PropLookup.TryGetValue(type, out props))
                {
                    props = new List<PropertyInfo>();
                    Dictionary<int, PropertyInfo> propsOrder =
                        new Dictionary<int, PropertyInfo>();
                    foreach (PropertyInfo p in GetType().GetProperties())
                    {
                        if (Attribute.IsDefined(p, typeof(WriteableAttribute)))
                        {
                            WriteableAttribute attr = (WriteableAttribute)p
                                .GetCustomAttributes(
                                    typeof(WriteableAttribute),
                                    inherit: true)[0];
                            propsOrder.Add(attr.Order, p);
                        }
                    }
                    props.AddRange(propsOrder
                        .OrderBy(kvp => kvp.Key)
                        .Select(kvp => kvp.Value));
                    PropLookup.Add(type, props);
                }
                return props;
            }
        }
   
        public IList<PropertyInfo> WriteableProperties()
        {
            return GetWritableProperties(GetType());
        }
    }
