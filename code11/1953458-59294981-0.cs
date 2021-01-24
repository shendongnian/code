    public static class TypeExt {
        public static bool IsBuiltin(this Type aType) => new[] { "/dotnet/shared/microsoft", "/windows/microsoft.net" }.Any(p => aType.Assembly.CodeBase.ToLowerInvariant().Contains(p));
        public static IEnumerable<Type> ImplementingTypes(this Type interfaceType, bool includeAbstractClasses = false, bool includeStructs = false, bool includeSystemTypes = false, bool includeInterfaces = false) =>
            AppDomain.CurrentDomain.GetAssemblies()
                                   .SelectMany(a => a.GetLoadableTypes())
                                   .Distinct()
                                   .Where(aType => (includeAbstractClasses || !aType.IsAbstract) &&
                                                   (includeInterfaces ? aType != interfaceType : !aType.IsInterface) &&
                                                   (includeStructs || !aType.IsValueType) &&
                                                   (includeSystemTypes || !aType.IsBuiltin()) &&
                                                   interfaceType.IsAssignableFrom(aType) &&
                                                   aType.GetInterfaces().Contains(interfaceType));
    }
    
    public static class AssemblyExt {
        //https://stackoverflow.com/a/29379834/2557128
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly) {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            try {
                return assembly.GetTypes();
            } catch (ReflectionTypeLoadException e) {
                return e.Types.Where(t => t != null);
            }
        }
    
    }
