    var path = @"path/to/dll/file.dll";
    var metadata = AssemblyMetadata.CreateFromFile(path);
    var module = metadata.GetModules().First();
    Console.WriteLine(module.Name);
    var reader = module.GetMetadataReader();
    
    var assemblyDef = reader.GetAssemblyDefinition();
    Console.WriteLine(reader.GetString(assemblyDef.Name));
    Console.WriteLine(assemblyDef.Version.ToString());
    foreach (var typeDefHandle in reader.TypeDefinitions)
    {
        var typeDef = reader.GetTypeDefinition(typeDefHandle);
        var fullName = (reader.GetString(typeDef.Namespace) + "::" + reader.GetString(typeDef.Name));
        Console.WriteLine(fullName);
    }
