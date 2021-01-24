    public static class AssemblyExtensions
    {
        public static Assembly[] ReflectionOnlyLoadReferencedAssemblies(this Assembly assembly) =>
            assembly.GetReferencedAssemblies()
                    .Select(a => Assembly.ReflectionOnlyLoad(a.FullName))
                    .ToArray();
    }
