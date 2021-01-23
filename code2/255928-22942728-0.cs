    public static dynamic CombineDynamics(dynamic dynamic1, dynamic dynamic2)
    {
      Dictionary<string, object> dictionary1 = GetKeyValueMap(dynamic1);
      Dictionary<string, object> dictionary2 = GetKeyValueMap(dynamic2);
    
      var result = new ExpandoObject();
      var d = result as IDictionary<string, object>;
    
      foreach (var pair in dictionary1.Concat(dictionary2))
      {
        d[pair.Key] = pair.Value;
      }
    
      return result;
    }
    
    private static Dictionary<string, object> GetKeyValueMap(object values)
    {
      var map = new Dictionary<string, object>();
      if (values != null)
      {
        foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
        {
          map.Add(descriptor.Name, descriptor.GetValue(values));
        }
      }
      return map;
    }
