    public bool HasInterface(TypeDefinition type, string interfaceFullName)
    {
      return (type.Interfaces.Any(i => i.FullName.Equals(interfaceFullName)) 
              || type.NestedTypes.Any(t => HasInterface(t, interfaceFullName)));
    }
