    var stringType = _module.TypeSystem.String;
    var system = _module.AssemblyResolver.Resolve ("System, Version= " + _module.TypeSystem.Corlib.Version);
    var generatedCodeAttribute = system.MainModule.GetType ("System.CodeDom.Compiler.GeneratedCodeAttribute");
    var generatedCodeCtor = generatedCodeAttribute.Methods.First (m => m.IsConstructor && m.Parameters.Count == 2);
    
    var result = new CustomAttribute (_module.Import (generatedCodeCtor));
    result.ConstructorArguments.Add(new CustomAttributeArgument(stringType, "ProcessedBySomething"));
    result.ConstructorArguments.Add(new CustomAttributeArgument(stringType, "1.0"));
