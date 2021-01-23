    private static MethodReference GetSystemObjectEqualsMethodReference(AssemblyDefinition assembly)
    {
        var @object = assembly.MainModule.TypeSystem.Object.Resolve ();
    
        return @object.Methods.Single(
            m => m.Name == "Equals"
                && m.Parameters.Count == 2
                && m.Parameters[0].ParameterType.MetadataType == MetadataType.Object
                && m.Parameters[1].ParameterType.MetadataType == MetadataType.Object);
    }
