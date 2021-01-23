    public class DefaultValueHelper
    {
        public static void InitializeDefaultValues<T>(T obj)
        {
            var properties =
                (from prop in obj.GetType().GetProperties()
                 let attr = GetDefaultValueAttribute(prop)
                 where attr != null
                 select new
                 {
                    Property = prop,
                    DefaultValue = attr.Value
                 }).ToArray();
            foreach (var p in properties)
            {
                p.Property.SetValue(obj, p.DefaultValue, null);
            }
                
        }
        
        private static DefaultValueAttribute GetDefaultValueAttribute(PropertyInfo prop)
        {
            return prop.GetCustomAttributes(typeof(DefaultValueAttribute), true)
                       .Cast<DefaultValueAttribute>()
                       .FirstOrDefault();
        }
    }
