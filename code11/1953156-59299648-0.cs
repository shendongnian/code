!objectType.IsAssignableFrom(specifiedType)
Looking into the error eventually turned up this [stackoverflow post][2].
The specific problem in my case was caused because my code was being called as a class library and the calling application was caching old .dll files in a temp folder after the first call. Because the dlls were technically different `Type.IsAssignable(Type)` returned false.
I ended up having to write a custom SerializationBinder and adding it to the JsonSerializerSettings parameter in order to make sure that consistent assemblies were used. (Implementation below). I am not sure if this was the best way to handle it, so if anyone has any alternative solutions or improvements...
class CustomSerializationBinder : ISerializationBinder
{
    private Dictionary<string, Assembly> assemblyLookup = new Dictionary<string, Assembly>();
    private Dictionary<string, Type> typeCache = new Dictionary<string, Type>();
    public CustomSerializationBinder(List<Assembly> problemAssemblies = null)
    {
        if (problemAssemblies == null) problemAssemblies = new List<Assembly>();
        foreach(Assembly assembly in problemAssemblies)
        {
            if(!assemblyLookup.ContainsKey(assembly.GetName().Name))
                this.assemblyLookup.Add(assembly.GetName().Name,assembly);
        }
        foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if(!assemblyLookup.ContainsKey(assembly.GetName().Name))
                assemblyLookup.Add(assembly.GetName().Name, assembly);
        }
    }
    public void BindToName(Type serializedType, out string assemblyName, out string typeName)
    {
        assemblyName = serializedType.Assembly.FullName;
        typeName = serializedType.FullName;
    }
    public Type BindToType(string assemblyName, string typeName)
    {
        Type resolvedType;
        Assembly resolvedAssembly;
        typeCache.TryGetValue(typeName, out resolvedType);
        if (resolvedType != null) return resolvedType;
        assemblyLookup.TryGetValue(assemblyName, out resolvedAssembly);
        if (resolvedAssembly == null) return null;
        resolvedType = resolvedAssembly.GetType(typeName);
        if (resolvedType != null)
            typeCache.Add(typeName, resolvedType);
        return resolvedType;
    }
}
  [1]: https://github.com/JamesNK/Newtonsoft.Json/blob/master/Src/Newtonsoft.Json/Serialization/JsonSerializerInternalReader.cs
  [2]: https://stackoverflow.com/questions/345413/isassignablefrom-returns-false-when-it-should-return-true
