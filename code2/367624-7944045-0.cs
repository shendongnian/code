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
        foreach(CompilerError CompErr in results.Errors)
        {
            textBox2.Text = textBox2.Text
                + "Line number " + CompErr.Line
                + ", Error Number: " + CompErr.ErrorNumber
                + ", '" + CompErr.ErrorText + ";"
                + Environment.NewLine + Environment.NewLine
                ;
        }
    }
