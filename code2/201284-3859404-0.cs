    var properties = this.GetType().Properties(
      BindingFlags.Instance 
      | BidningFlags.NonPublic 
      | BindingFlags.Public);
    foreach(PropertyInfo property in properties)
    {
        // if a property is declared on a base type with a private setter,
        // get the definition again from the declaring type,
        // unless you can't call the setter.
        // Probably it is even more reliable to get the properties setter
        // from the declaring type.
        if (property.DeclaringType != this)
        {
          property = property.DeclaringType.GetProperty(
            property.PropertyName,
            BindingFlags.Instance 
            | BidningFlags.NonPublic 
            | BindingFlags.Public);
        }
        
        if (property.CanWrite)
        {
          // assumed that you define a dictionary having the default values.
          property.SetValue(this, defaultValues[property.PropertyType];
        }
    }
