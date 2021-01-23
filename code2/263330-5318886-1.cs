    public static class TypeExtensions {
       public static IEnumerable<Type> GetInterfaces(this Type type, bool includeInherited)
       {
          if (includeInherited || type.BaseType == null)
             return type.GetInterfaces();
          else
             return type.GetInterfaces().Except(type.BaseType.GetInterfaces());
       }
    }
