    using Mono.Cecil;
    using Mono.Cecil.Rocks;
    ...
    var asm = AssemblyDefinition.ReadAssembly("MyAssembly.dll");
    var types = asm.MainModule.GetAllTypes();
