    var codeProvider = new CSharpCodeProvider();
    ICodeCompiler icc = codeProvider.CreateCompiler();
    
    var parameters = new CompilerParameters()
    {
        GenerateExecutable = true,
        OutputAssembly = Output,
    };
    CompilerResults results = icc.CompileAssemblyFromSource(parameters, sourceString);
    if (results.Errors.Count > 0)
    {
        foreach(CompilerError error in results.Errors)
        {
            textBox2.Text = textBox2.Text
                + "Line number " + error.Line
                + ", Error Number: " + error.ErrorNumber
                + ", '" + error.ErrorText + ";"
                + Environment.NewLine + Environment.NewLine
                ;
        }
    }
