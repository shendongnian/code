      static void CompileCSharp(string code) {
        CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
        ICodeCompiler compiler = provider.CreateCompiler();
        CompilerParameters parameters = new CompilerParameters();
        parameters.OutputAssembly = @"D:\foo.exe";
        parameters.GenerateExecutable = true;
        CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code);
        if (results.Output.Count == 0)
        {
            Console.WriteLine("success!");
        }
        else
        {
            CompilerErrorCollection CErros = results.Errors;
            foreach (CompilerError err in CErros)
            {
                string msg = string.Format("Erro:{0} on line{1} file name:{2}", err.Line, err.ErrorText, err.FileName);
                Console.WriteLine(msg);
            }
        }
    }
