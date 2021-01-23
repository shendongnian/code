    using System.CodeDom.Compiler;
    using System.Diagnostics;
    using Microsoft.CSharp;
    private void button1_Click(object sender, System.EventArgs e)
    {
        CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        ICodeCompiler icc = codeProvider.CreateCompiler();
        string Output = "Out.exe";
        Button ButtonObject = (Button)sender;
    
        textBox2.Text = "";
        System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
        //Make sure we generate an EXE, not a DLL
        parameters.GenerateExecutable = true;
        parameters.OutputAssembly = Output;
        CompilerResults results = icc.CompileAssemblyFromSource(parameters, textBox1.Text);
    
        if (results.Errors.Count > 0)
        {
            textBox2.ForeColor = Color.Red;
            foreach (CompilerError CompErr in results.Errors)
            {
                textBox2.Text = textBox2.Text +
                            "Line number " + CompErr.Line +
                            ", Error Number: " + CompErr.ErrorNumber +
                            ", '" + CompErr.ErrorText + ";" +
                            Environment.NewLine + Environment.NewLine;
            }
        }
        else
        {
            //Successful Compile
            textBox2.ForeColor = Color.Blue;
            textBox2.Text = "Success!";
            //If we clicked run then launch our EXE
            if (ButtonObject.Text == "Run") Process.Start(Output);
        }
    }
