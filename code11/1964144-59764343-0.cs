csharp
public static List<Type> AllAccessiableEnums()
{
    var entry = Assembly.GetEntryAssembly();
    var referenced = entry
        .GetReferencedAssemblies()
        .ToList()
        .Select(t => Assembly.Load(t));
    
    referenced.Add(entry);
    return referenced
        .SelectMany(t => t.GetTypes())
        .Where(t => t.IsEnum)
        .ToList();
}
