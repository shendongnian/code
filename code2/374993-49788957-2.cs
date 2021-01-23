    public interface ITypeResolver
    {
        string GetName(Type type);
        Type GetType(Assembly assembly, string typeName);
    }
    
    class TypeResolver : ITypeResolver
    {
        public string GetName(Type type) => type.AssemblyQualifiedFillName;
        public Type GetType(Assembly assembly, string typeName) =>
            assembly.GetType(typeName) ?? Type.GetType(typeName);
    }
