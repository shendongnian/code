csharp
var searchForType = typeof(IHashCommand);
var types = AppDomain.CurrentDomain.GetAssemblies()
        .Where(assembly => !assembly.FullName.Contains("Hidden") && !assembly.FullName.Contains("Private"))
        .SelectMany(assembly => assembly.GetTypes())
        .Where(type => !type.IsInterface && !type.IsAbstract && searchForType.IsAssignableFrom(type));
