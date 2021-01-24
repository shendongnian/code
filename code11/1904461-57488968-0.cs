            public virtual string counts => typeof(Changeset)
            .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
            .Where(prop => prop.GetValue(this) != null && count(prop) > 0)
            .Select(prop => $@".{prop.Name}.Count == {count(prop)}")
            .Join("\n");
        private int count(PropertyInfo prop)
        {
            var name = prop.Name;
            var isetInterface = prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ISet<>)
                ? prop.PropertyType
                : null;
            if (isetInterface == null)
            {
                isetInterface = prop.PropertyType
                    .GetInterfaces()
                    .FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ISet<>));
            }
            if (isetInterface != null)
            {
                object isetPropertyValue = prop.GetValue(this);
                var countPropertyInfo = isetInterface
                    .GetInterfaces()
                    .First(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>))
                    .GetProperty("Count");
                if (isetPropertyValue == null)
                    return 0;
                else
                    return (int) countPropertyInfo.GetValue(isetPropertyValue);
            }
            return 0;
        }
