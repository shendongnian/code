    var rp = new Mono.Cecil.ReaderParameters() { AssemblyResolver = new MyAssemblyResolver() };
    var assemblyDefinition = Mono.Cecil.AssemblyDefinition.ReadAssembly(assemblyStream, rp);
    var astBuilder = new ICSharpCode.Decompiler.Ast.AstBuilder(
         new ICSharpCode.Decompiler.DecompilerContext(assemblyDefinition.MainModule));
    astBuilder.AddAssembly(assemblyDefinition);
