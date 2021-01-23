    public static IEnumerable<FieldInfo> GetAllFields(Type objectType)
    {      
          //GetFields(...) returns a FieldInfo []
          var fields = objectType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
          if(objectType.BaseType==null) return fields;
          return fields.Concat(GetAllFields(object.BaseType));
     }
