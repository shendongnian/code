    public static class ParameterInfoExtensions
    {
      public static bool TryGetDeclaringProperty(this ParameterInfo pi, out PropertyInfo prop)
      {
        MethodInfo mi = pi.Member as MethodInfo;
        if (mi != (MethodInfo)null && mi.IsSpecialName 
            && mi.Name.StartsWith("set_", StringComparison.Ordinal) 
            && mi.DeclaringType != (Type)null)
        {
          prop = mi.DeclaringType.GetTypeInfo().GetDeclaredProperty(mi.Name.Substring(4));
          return true;
        }
        prop = null;
        return false;
      }
    }
