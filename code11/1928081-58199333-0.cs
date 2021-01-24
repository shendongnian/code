    public class ExecutionAssemblyLoadContext : AssemblyLoadContext
    {
        public ExecutionAssemblyLoadContext() : base(isCollectible: true)
        {
        }
        protected override Assembly Load(AssemblyName name)
        {
            return null;
        }
    }
