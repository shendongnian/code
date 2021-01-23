    public static IEnumerable<FieldInfo> GetAllFields(Type objectType)
    {
       if (objectType == null)
          return Enumerable<FieldInfo>.Empty;
       else 
          return objectType.GetFields(
                     BindingFlags.NonPublic | BindingFlags.Public |
                     BindingFlags.Instance | BindingFlags.DeclaredOnly)
             .Concat(GetAllFields(objectType.BaseType));
    }
