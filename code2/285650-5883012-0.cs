    var assemblyResolver = new DefaultAssemblyResolver();
    assemblyResolver.AddSearchDirectory(...);
    var assemblyDefinition = assemblyResolver.Resolve(
                                 AssemblyNameReference.Parse(fullName));
    foreach(ModuleDefinitionmodule in assemblyDefinition)
    {
        foreach(TypeDefinition type in module.Types)
        {
            foreach(MethodDefinition method in type.Methods)
            {
                foreach(Instruction instruction in method.Body.Instructions)
                {
                    // Analyze it - the hard part ;-)
                }
            }
        }
    }
