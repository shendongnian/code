    public static class DataTableExtensions
    {
        [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
        public sealed class IgnoreAttribute : Attribute { public IgnoreAttribute() { } }
        private static Dictionary<Type, IList<PropertyInfo>> typeDictionary = new Dictionary<Type, IList<PropertyInfo>>();
        public static IList<PropertyInfo> GetPropertiesForType<T>()
        {
            var type = typeof(T);
            if (!typeDictionary.ContainsKey(typeof(T)))
                typeDictionary.Add(type, type.GetProperties().ToList());
            return typeDictionary[type];
        }
        public static IList<T> ToList<T>(this DataTable table) where T : new()
        {
            IList<PropertyInfo> properties = GetPropertiesForType<T>();
            IList<T> result = new List<T>();
            foreach (var row in table.Rows)
                result.Add(CreateItemFromRow<T>((DataRow)row, properties));
            return result;
        }
        private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
        {
            T item = new T();
            foreach (var property in properties)
            {
                // Only load those attributes NOT tagged with the Ignore Attribute
                var atr = property.GetCustomAttribute(typeof(IgnoreAttribute));
                if (atr == null)
                    property.SetValue(item, row[property.Name], null);
            }
            return item;
        }
    }
