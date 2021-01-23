    var countProp = entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).First(p => p.Name == "Count");
    var count = (int)countProp.GetValue(entity,null);
    
    if(count == 0)
    {
       var method = entity.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public).First(m => m.Name == "Add");
       method.Invoke(entity,new instance of type);
    }
