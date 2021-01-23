    using Mono.Cecil;
    public class IgnoringExceptionsAssemblyResolver : DefaultAssemblyResolver
    {
        public override AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            try
            {
                return base.Resolve(name);
            }
            catch
            {
                return null;
            }
        }
    }
