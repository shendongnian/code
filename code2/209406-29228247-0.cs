    Mono.Cecil.ReaderParameters readerParameters = new Mono.Cecil.ReaderParameters { ReadSymbols = true };
    Mono.Cecil.AssemblyDefinition assemblyDefinition = Mono.Cecil.AssemblyDefinition.ReadAssembly(string.Format("Library\\ScriptAssemblies\\{0}.dll", assemblyName), readerParameters);
    string fileName = string.Empty;
    int lineNumber = -1;
    
    Mono.Cecil.TypeDefinition typeDefinition = assemblyDefinition.MainModule.GetType(myType.FullName);
    for (int index = 0; index < typeDefinition.Methods.Count; index++)
    {
        Mono.Cecil.MethodDefinition methodDefinition = typeDefinition.Methods[index];
        if (methodDefinition.Name == methodName)
        {
            Mono.Cecil.Cil.MethodBody methodBody = methodDefinition.Body;
            if (methodBody.Instructions.Count > 0)
            {
                Mono.Cecil.Cil.SequencePoint sequencePoint = methodBody.Instructions[0].SequencePoint;
                fileName = sequencePoint.Document.Url;
                lineNumber = sequencePoint.StartLine;
            }
        }
    }
