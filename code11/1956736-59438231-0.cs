    static void Main(string[] args)
    {
        var code = System.IO.File.ReadAllText(@"C:\program.txt");
        CompileAndRun(code);
        Console.ReadKey();
    }
  
    static void CompileAndRun(string code)
    {
        CompilerParameters CompilerParams = new CompilerParameters();
        string outputDirectory = Directory.GetCurrentDirectory();
        CompilerParams.GenerateInMemory = true;
        CompilerParams.TreatWarningsAsErrors = false;
        CompilerParams.GenerateExecutable = false;
        CompilerParams.CompilerOptions = "/optimize";
        string[] references = { "System.dll" };
        CompilerParams.ReferencedAssemblies.AddRange(references);
        CSharpCodeProvider provider = new CSharpCodeProvider();
        CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);
        // ...
    }
