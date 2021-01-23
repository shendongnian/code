    public static void DenullStringProperties<T>(this T instance)
    {
        foreach(var propertyInfo in instance.GetType().GetProperties().
                                       Where(p => p.PropertyType == typeof(string))
        {
            var value = propertyInfo.GetValue(instance, null);
            if(value == null)
                value = string.Empty;
            propertyInfo.SetValue(instance, value, null);
        }
    }
