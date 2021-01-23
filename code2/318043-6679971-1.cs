    DefaultAssemblyResolver assemblyResolver = new DefaultAssemblyResolver();
    // so it won't complain about not finding assemblies sitting in the same directory as the dll/exe we are goi\
    ng to patch
    assemblyResolver.AddSearchDirectory(assemblyDirectory);
    var readerParameters = new ReaderParameters { AssemblyResolver = assemblyResolver };
    AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(assemblyFilename, readerParameters);
    foreach (var moduleDefinition in assembly.Modules)
    {
        foreach (var type in ModuleDefinitionRocks.GetAllTypes(moduleDefinition))
        {
            foreach (var method in type.Methods)
            {
                if (!HasAttribute("MyCustomAttribute", method.method.CustomAttributes)
                {
                  ILProcessor ilProcessor = method.Body.GetILProcessor();
                  ilProcessor.InsertBefore(method.Body.Instructions.First(), ilProcessor.Create(OpCodes.Call, thre\
    adCheckerMethod));
    ...
    private static bool HasAttribute(string attributeName, IEnumerable<CustomAttribute> customAttributes)
    {
        return GetAttributeByName(attributeName, customAttributes) != null;
    }
    private static CustomAttribute GetAttributeByName(string attributeName, IEnumerable<CustomAttribute> customAttributes)
    {
        foreach (var attribute in customAttributes)
            if (attribute.AttributeType.FullName == attributeName)
                return attribute;
        return null;
    }
