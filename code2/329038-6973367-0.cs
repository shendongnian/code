    List<PropertyInfo> l = new List<PropertyInfo>();
    
    foreach(PropertyInfo prop in t.GetProperties())
    {
      if(Attribute.IsDefined(prop, typeof(MyAttribute))
        l.Add(prop);
    }
