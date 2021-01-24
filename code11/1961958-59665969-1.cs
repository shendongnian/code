    IEnumerable<IEnumerable<KeyValuePair<string,object>>> GetTypesAttribute<T>(Assembly assembly) where T:Attribute
    {
      
       return assembly.GetTypes().Where(x=> x.GetCustomAttributes(typeof(T)).Any())
       							.Select(x=> x.GetCustomAttribute(typeof(T)))
    							.Select(x=> x.GetType().GetProperties().Select(c=> new KeyValuePair<string,object>(c.Name,c.GetValue(x))));
    }
