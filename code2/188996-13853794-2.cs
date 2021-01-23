    Type GenerateDynamicType(string sourceCode, string typenameToGet)
    {
        var cp = new System.CodeDom.Compiler.CompilerParameters
        {
            GenerateInMemory = true,    // you will get a System.Reflection.Assembly back
            GenerateExecutable = false, // Dll
            IncludeDebugInformation = false,
            CompilerOptions = ""
        };
        var csharp = new Microsoft.CSharp.CSharpCodeProvider();
        // this actually runs csc.exe:
        System.CodeDom.Compiler.CompilerResults cr =
              csharp.CompileAssemblyFromSource(cp, sourceCode);
        // cr.Output contains the output from the command
        if (cr.Errors.Count != 0)
        {
            // handle errors
            throw new InvalidOperationException("error at dynamic expression compilation");
        }
        System.Reflection.Assembly a = cr.CompiledAssembly;
        // party on the type here, either via reflection...
        Type t = a.GetType(typenameToGet);
        return t;
    }
