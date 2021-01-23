    public static class TypeExtensions
    {       
        public static TAttribute GetAttribute<TAttribute>(this Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(TAttribute), true);
            if (attributes.Length == 0) return default(TAttribute);
            return (TAttribute)attributes[0];
        }      
        public static PropertyInfo GetPropertyWithAttributeValue<TAttribute>(
            this IEnumerable<PropertyInfo> properties,
            Func<TAttribute, bool> findPredicate)
            where TAttribute : Attribute
        {
            var property = from p in properties
                           where p.HasAttribute<TAttribute>() &&
                           findPredicate.Invoke(p.GetAttribute<TAttribute>())
                           select p;
            return property.FirstOrDefault();
        }
        public static bool HasAttribute<TAttribute>(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes(typeof(TAttribute), true).Any();
        }
        public static TAttribute GetAttribute<TAttribute>(this PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(TAttribute), true);
            if (attributes.Length == 0) return default(TAttribute);
            return (TAttribute)attributes[0];
        }
    }
