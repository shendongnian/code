c#
public class PluginAssemblyContext : AssemblyLoadContext
{
    private readonly AssemblyDependencyResolver _resolver;
    public PluginAssemblyContext(string mainAssemblyToLoadPath) : base(isCollectible: true)
    {
        _resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
    }
    protected override Assembly Load(AssemblyName name)
    {
        string assemblyPath = _resolver.ResolveAssemblyToPath(name);
        if (assemblyPath != null)
        {
            return LoadFromAssemblyPath(assemblyPath);
        }
        return null;
    }
}
Define this class somewhere within a namespace with proper **using**s...
c#
public static class PluginAssemblyContextExtensions
{
    public static Assembly FromAssemblyPath(this AssemblyLoadContext context, string path)
    {
    
        return context.LoadFromAssemblyPath(path);
    
    }
}
...from somewhere else (preferably within a static method/constructor), call the above code when your app has finished starting. I didn't have a chance to test this but I suspect the smell of your code comes from within the PluginAssemblyContext constructor you defined. Please let me know if I'm right (or wrong).
