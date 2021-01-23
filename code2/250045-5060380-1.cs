    oCodeDomProvider = CodeDomProvider.CreateProvider("CSharp");
    // Add what referenced assemblies
    CompilerParameters oCompilerParameters = new CompilerParameters();
    oCompilerParameters.ReferencedAssemblies.Add("system.dll");
    // set the compiler to create a DLL
    oCompilerParameters.GenerateExecutable = false;
    // set the dll to be created in memory and not on the hard drive
    oCompilerParameters.GenerateInMemory = true;
    oCompilerResults =
      oCodeDomProvider.CompileAssemblyFromSource(oCompilerParameters, szCode);
