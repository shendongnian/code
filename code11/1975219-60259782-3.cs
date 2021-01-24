c#
public static Assembly[] MyPlugins { get; private set; }
public static void LoadAssemblies()
{
   MyPlugins = Directory.GetFiles(lookingDirectory, "*.dll")
                .Select(assemblyPath =>
                {
                    AssemblyName an = AssemblyName.GetAssemblyName(assemblyPath);
                    return Assembly.Load(an);
                })
                .ToArray();
}
And then you can find all types that implements your interface like this :
c#
MyPlugins.SelectMany(assembly => assembly.GetTypes())
    .Where(type => typeof(IYourInterface).IsAssignableFrom(type))
    .Select(type => (IYourInterface)Activator.CreateInstance(type))
And then you can iterate on each implementation of your interface to call a shared method for example.
