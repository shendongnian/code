var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
foreach (var assembly in Directory.GetFiles(path, "*.dll"))
{
    Assembly.LoadFile(assembly);
}
When comparing the loaded assembly with Assembly.GetExecutingAssembly(), the assemblies are not equal. Since types have references to their respective assemblies, the types were therefore not equal. Moving to use `AppDomain.CurrentDomain.GetAssemblies()` solved the problem, as I was loading assemblies already loaded by the application.
