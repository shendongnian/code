    public class ModAssemblyLoadContext : AssemblyLoadContext
    {
        public ModAssemblyLoadContext()
            : base("ModAssemblyLoadContext", isCollectible: true)
        {
        }
        protected override Assembly Load(AssemblyName assemblyName)
        {
            return Default.Assemblies
                .FirstOrDefault(x => x.FullName == assemblyName.FullName);
        }
    }
