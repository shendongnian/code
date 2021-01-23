    foreach (PropertyInfo property in properties)  
    {
      if (property.PropertyType.IsGenericType)
      {
        var subtypes = property.PropertyType.GetGenericArguments();
        // construct full type name from type and subtypes.
      }
      else
      {
        code += "this." + property.Name + " = default(" + property.PropertyType.Name + ")";  
      }
    }
