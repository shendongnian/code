    using Mono.Cecil;
    public class IgnoringExceptionsAssemblyResolver : BaseAssemblyResolver
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
