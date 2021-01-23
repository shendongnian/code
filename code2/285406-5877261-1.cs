    public static Assembly Compile(string source)
    {
        var codeProvider = new CSharpCodeProvider(new Dictionary<String, String> { { "CompilerVersion", "v4.0" } });
        var compilerParameters = new CompilerParameters();
        compilerParameters.ReferencedAssemblies.Add("System.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Xml.dll");
        compilerParameters.ReferencedAssemblies.Add("System.Xml.Linq.dll");
        compilerParameters.CompilerOptions = "/t:library";
        compilerParameters.GenerateInMemory = true;
        var result = codeProvider.CompileAssemblyFromSource(compilerParameters, source);
        if (result.Errors.Count > 0)
        {
            foreach (CompilerError error in result.Errors)
            {
                Debug.WriteLine("ERROR Line {0:000}: {1}", error.Line, error.ErrorText);
            }
            return null;
        }
        else
        {
            return result.CompiledAssembly;
        }
    }
