    Assembly assembly = Assembly.GetExecutingAssembly();
    AssemblyName assemblyName = assembly.GetName();
    var fileHelperEngine = Type emptyGenericType = typeof(FileHelperEngine<>);
    Type genericTypeArgument = assembly.GetType(assemblyName.Name + ".FileDefinitions." + className);
    Type completeGenericType = emptyGenericType.MakeGenericType(genericTypeArgument);
    var fileHelperEngine = Activator.CreateInstance(completeGenericType);
