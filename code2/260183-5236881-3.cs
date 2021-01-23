    var genericTypes = types.Where(type => type.HasGenericParameters);
    var genericMethods = types.
      Select(type => 
        type.Methods.Where(method => method.HasGenericParameters));
    var genericFields = types.
      Select(type => 
        type.Fields.Where(field => field.DeclaringType.HasGenericParameters));
    var genericMethodInstructions = types.Select(type =>
      type.Methods.Where(method => method.HasBody).
      Select(method => method.Body.Instructions.
        Where(instruction => instruction.Operand is MethodReference).
        Select(instruction => (MethodReference)instruction.Operand).
        Where(methodRef => methodRef.Resolve().HasGenericParameters)));
