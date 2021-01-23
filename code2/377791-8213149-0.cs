    ICodeCompiler comp = (new CSharpCodeProvider().CreateCompiler());
    CompilerParameters cp = new CompilerParameters();
    cp.ReferencedAssemblies.Add("system.dll");
    cp.ReferencedAssemblies.Add("system.data.dll");
    cp.ReferencedAssemblies.Add("system.xml.dll");
    cp.GenerateExecutable = false;
    cp.GenerateInMemory = true;
    CompilerResults cr = comp.CompileAssemblyFromSource(cp, code.ToString());
    if (cr.Errors.HasErrors)
    {
        StringBuilder error = new StringBuilder();
        error.Append("Error Compiling Expression: ");
        foreach (CompilerError err in cr.Errors)
        {
            error.AppendFormat("{0}\n", err.ErrorText);
        }
        throw new Exception("Error Compiling Expression: " + error.ToString());
    }
    Assembly a = cr.CompiledAssembly;
