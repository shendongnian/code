    var setMethod = (from method in typeof(ObservableObject).GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                     where method.Name == "Set"
                     let parameters = method.GetParameters()
                     where parameters.Length == 3 &&
                     parameters[0].ParameterType.IsByRef &&
                     parameters[0].ParameterType.ContainsGenericParameters &&
                     parameters[1].ParameterType.ContainsGenericParameters &&
                     parameters[2].ParameterType == typeof(string)
                     select method).Single().MakeGenericMethod(propertyType);
    // set => Set(ref _Name, value);
    setIl.Emit(OpCodes.Ldarg_0); // Load 'this' -- we'll use it when calling Set later
    // Stack: [this]
    setIl.Emit(OpCodes.Ldarg_0); // Load 'this' again, for accessing 'this.field'
    // Stack: [this, this]
    setIl.Emit(OpCodes.Ldflda, fieldBuilder); // Load the address of 'this.field'
    // Stack: [this, ref this.field]
    setIl.Emit(OpCodes.Ldarg_1); // Load 'value'
    // Stack: [this, ref this.field, value]
    setIl.Emit(OpCodes.Ldstr, propertyName); // Load 'propertyName'
    // Stack: [this, ref this.field, value, propertyName]
    setIl.Emit(OpCodes.Call, setMethod);
    // Stack: [bool]
    setIl.Emit(OpCodes.Pop); // Pop the returned value
    // Stack: []
    setIl.Emit(OpCodes.Ret);
