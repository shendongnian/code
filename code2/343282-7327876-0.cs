    public static void MergeFrom<T>(this object destination, T source)
    {
        Type destinationType = destination.GetType();
		//in case we are dealing with DTOs or EF objects then exclude the EntityKey as we know it shouldn't be altered once it has been set
		PropertyInfo[] propertyInfos = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => !string.Equals(x.Name, "EntityKey", StringComparison.InvariantCultureIgnoreCase)).ToArray();
        foreach (var propertyInfo in propertyInfos)
        {
            PropertyInfo destinationPropertyInfo = destinationType.GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance);
            if (destinationPropertyInfo != null)
            {
                if (destinationPropertyInfo.CanWrite && propertyInfo.CanRead && (destinationPropertyInfo.PropertyType == propertyInfo.PropertyType))
                {
                    object o = propertyInfo.GetValue(source, null);
                    destinationPropertyInfo.SetValue(destination, o, null);
                }
            }
        }
    }
