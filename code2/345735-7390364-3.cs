    foreach (var prop in tProps) {  
      var id=prop.GetValue(item, null);
      if (id!=null) {  
        var type = prop.GetCustomAttributes(typeof(EnumerationAttribute>,true).OfType<EnumerationAttribute>().Select(x=>x.Enumeration).First();
        var enumerationType=typeof(Enumeration<>).MakeGenericType(type);
        var fromIdMethod=enumerationType.GetMethod("FromId",BindingFlags.Public|BindingFlags.Static|BindingFlags.InvokeMethod);
        var displayName=fromIdMethod.Invoke(null,new object[] {id});
        prop.SetValue(item, displayName);  
      }  
    }  
