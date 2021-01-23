    string code = "class foo { static void Main(string[] args) { System.Console.Write(\"Hello :)\"); } }";
    CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
    ICodeCompiler compiler = provider.CreateCompiler();
    CompilerParameters parameters = new CompilerParameters();
    parameters.OutputAssembly = @"C:\output\foo.exe";
    parameters.GenerateExecutable = true;
    CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code);
    if (results.Output.Count == 0)
    {
        Console.WriteLine("success!");
    }
    else 
    {
     //An error occurred, do something
    }
