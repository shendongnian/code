    public static class TypeExt {
        public static bool IsBuiltin(this Type aType) => new[] { "/dotnet/shared/microsoft", "/windows/microsoft.net" }.Any(p => aType.Assembly.CodeBase.ToLowerInvariant().Contains(p));
    
        static Dictionary<Type, HashSet<Type>> FoundTypes = null;
        static List<Type> LoadableTypes = null;
    
        public static void RefreshLoadableTypes() {
            LoadableTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetLoadableTypes()).ToList();
            FoundTypes = new Dictionary<Type, HashSet<Type>>();
        }
    
        public static IEnumerable<Type> ImplementingTypes(this Type interfaceType, bool includeAbstractClasses = false, bool includeStructs = false, bool includeSystemTypes = false, bool includeInterfaces = false) {
            if (FoundTypes != null && FoundTypes.TryGetValue(interfaceType, out var ft))
                return ft;
            else {
                if (LoadableTypes == null)
                    RefreshLoadableTypes();
    
                var ans = LoadableTypes
                           .Where(aType => (includeAbstractClasses || !aType.IsAbstract) &&
                                           (includeInterfaces ? aType != interfaceType : !aType.IsInterface) &&
                                           (includeStructs || !aType.IsValueType) &&
                                           (includeSystemTypes || !aType.IsBuiltin()) &&
                                           interfaceType.IsAssignableFrom(aType) &&
                                           aType.GetInterfaces().Contains(interfaceType))
                           .ToHashSet();
    
                FoundTypes[interfaceType] = ans;
    
                return ans;
            }
        }
    }
    
    public static class AssemblyExt {
        //https://stackoverflow.com/a/29379834/2557128
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly) {
            if (assembly == null)
                throw new ArgumentNullException("assembly");
            try {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e) {
                return e.Types.Where(t => t != null);
            }
        }
    }
