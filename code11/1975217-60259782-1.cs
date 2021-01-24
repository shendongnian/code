c#
public static Assembly[] MyPlugins { get; private set; }
public static void LoadAssemblies()
{
   Assemblies = Directory.GetFiles(lookingDirectory, "*.dll")
                .Select(Assembly.LoadFrom)
                .ToArray();
}
And then you can find all types that implements your interface like this :
c#
Assemblies.SelectMany(assembly => assembly.GetTypes)
    .Where(type => typeof(IYourInterface).IsAssignableFrom(type))
    .Select(type => (IYourInterface)Activator.CreateInstance(type))
And then you can iterate on each implementation of your interface to call a shared method for example.
