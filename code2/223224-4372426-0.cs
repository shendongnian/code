    private static MethodReference GetSystemObjectEqualsMethodReference(AssemblyDefinition assembly)
    {
        var typeReference = assembly.MainModule.GetTypeReferences()
            .Single(t => t.FullName == "System.Object");
    
        var typeDefinition = typeReference.Resolve();
    
        var methodDefinition = typeDefinition.Methods.Single(
                                m => m.Name == "Equals"
                                    && m.Parameters.Count == 2
                                    && m.Parameters[0].ParameterType.Name == "Object"
                                    && m.Parameters[1].ParameterType.Name == "Object"
        );
    
        return methodDefinition;
    }
