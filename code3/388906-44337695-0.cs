    public static class TypeExtensions {
       public static void EnsureAssemblyLoads(this Type pType) {
          // do nothing
       }
    }
    ...
    typeof(SomeType).EnsureAssemblyLoads();
