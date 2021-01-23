    public IEnumerable<string> GetAssembliesFromInheritance (TypeDefinition type)
    {
        while (type != null) {
            yield return type.Module.FullyQualifiedName;
    
            if (type.BaseType == null)
                yield break;
    
            type = type.BaseType.Resolve ();
        }
    }
