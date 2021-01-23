    public void Map<TSource, TDestination>(TSource source, TDestination destination)
    {
      var props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
      var type = typeof(TDestination);
      
      foreach (var prop in props)
      {
        object value = prop.GetValue(source, null);
        
        var prop2 = type.GetProperty(prop.Name);
        if (prop2 == null)
          continue;
          
        if (prop.PropertyType != prop2.PropertyType)
          continue;
          
        prop2.SetValue(destination, value, null);
      }
    }
