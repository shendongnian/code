    List<PropertyInfo> props = new List<PropertyInfo> ();
    
    foreach (PropertyInfo prop in t.GetProperties())
    {
        if ( Attribute.IsDefined(prop, typeof(MyAttribute)) )
             props.Add (prop);
    }
