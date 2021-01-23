    var objSetProps = instanceOfObjectContext.GetType().GetProperties().Where(prop => prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(ObjectSet<>));
    foreach(PropertyInfo objSetProp in objSetProps)
    {
        var objSet = objSetProp.GetValue(instanceOfObjectContext, BindingFlags.GetProperty, null, null, null);
    }
