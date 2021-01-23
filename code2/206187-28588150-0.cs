        private static IEnumerable<Assembly> GetAllDependencies(Assembly assembly)
        {
            var dict = new Dictionary<string, AssemblyName>();
            dict.Add(assembly.GetName().FullName, assembly.GetName());
            dict = GetAllDependenciesRecursive(assembly.GetName(), dict);
            return dict.Select(d => Assembly.Load(d.Value)).ToArray();
        }
        private static Dictionary<string, AssemblyName> GetAllDependenciesRecursive(AssemblyName assemblyName, Dictionary<string, AssemblyName> existingRefList)
        {
            var assembly = Assembly.Load(assemblyName);
            List<AssemblyName> a = assembly.GetReferencedAssemblies().ToList();
            foreach (var refAssemblyName in a)
            {
                if (!existingRefList.ContainsKey(refAssemblyName.FullName))
                {
                    existingRefList.Add(refAssemblyName.FullName, refAssemblyName);
                    existingRefList = GetAllDependenciesRecursive(refAssemblyName, existingRefList);
                }
            }
            return existingRefList;
        }
