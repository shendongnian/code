    private T CreateOnAppDomain<T>() {
        var type = typeof(T);
        return (T) this.appDomain.CreateInstanceFromAndUnwrap(
            type.Assembly.Location,
            type.FullName
        );
    }
    public void LoadAssemblies() {
        var assemblyLoader = CreateOnAppDomain<AssemblyLoader>();
        assemblyLoader.LoadAssembly(myInterfaceAssembly.GetName(true));
        foreach (var assemblyName in this.assemblyNames) {
            assemblyLoader.LoadAssembly(new AssemblyName(assemblyName));
        }
    }
    class AssemblyLoader : MarshalByRefObject {
        public void LoadAssembly(AssemblyName name) {
            Assembly.Load(name);
        }
    }
