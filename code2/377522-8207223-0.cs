    public class InitOnLoadAttribute : Attribute {}
    private void InitAssembly(Assembly assembly)
    {
        foreach (var type in GetLoadOnInitTypes(assembly)){
            var prop = type.GetProperty("loaded", BindingFlags.Static | BindingFlags.NonPublic); //note that this only exists by convention
            if(prop != null){
                prop.GetValue(null, null); //causes the static ctor to be called if it hasn't already
            }
        }
     }
    static IEnumerable<Type> GetLoadOnInitTypes(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(InitOnLoadAttribute), true).Length > 0){
                yield return type;
            }
        }
    }
    public MyMainClass()
    {
        //init newly loaded assemblies
        AppDomain.CurrentDomain.AssemblyLoad += (s, o) => InitAssembly(o.LoadedAssembly); 
        //and all the ones we currently have loaded
        foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies()){
            InitAssembly(assembly);
        }
    }
