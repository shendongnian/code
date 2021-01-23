    static bool HasAttribute (PropertyInfo property, string attribute) {
      if (property == null)
        return false;
    
      if (GetCustomAttributes ().Any (a => a.GetType ().Name == attribute))
        return true;
    
      var interfaces = property.DeclaringType.GetInterfaces ();
    
      for (int i = 0; i < interfaces.Length; i++)
        if (HasAttribute (interfaces[i].GetProperty (property.Name), attribute)
          return true;
    
      return false;
    }
