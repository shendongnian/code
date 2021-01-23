    foreach (PropertyInfo property in properties)  
    {
      if (property.Type.IsGenericType)
      {
        var subtypes = property.Type.GetGenericArguments();
        // construct full type name from type and subtypes.
      }
      else
      {
        code += "this." + property.Name + " = default(" + property.PropertyType.Name + ")";  
      }
    }
