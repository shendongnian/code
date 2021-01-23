    public static IEnumerable<Tuple<PropertyInfo, FieldAttribute>> GetFieldAttributes<T>()
    {
        var properties = typeof(T).GetProperties();
        foreach (var prop in properties)
        {
            var attribute = prop.GetCustomAttributes(typeof(FieldAttribute), true).FirstOrDefault();
            if (attribute != null)
            {
                yield return new Tuple<PropertyInfo, FieldAttribute>(prop, attribute);
            }
        }
    }
