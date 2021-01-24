    void Run(string code, string formName)
    {
        var csc = new CSharpCodeProvider();
        var parameters = new CompilerParameters(new[] {
        "mscorlib.dll",
        "System.Windows.Forms.dll",
        "System.dll",
        "System.Drawing.dll",
        "System.Core.dll",
        "Microsoft.CSharp.dll"});
        parameters.GenerateExecutable = true;
        code = $@"
            {code}
            public class Program
            {{
                [System.STAThread]
                static void Main()
                {{
                    System.Windows.Forms.Application.EnableVisualStyles();
                    System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                    System.Windows.Forms.Application.Run(new {formName}());
                }}
            }}";
        var results = csc.CompileAssemblyFromSource(parameters, code);
        if (!results.Errors.HasErrors)
        {
            System.Diagnostics.Process.Start(results.CompiledAssembly.CodeBase);
        }
        else
        {
            var errors = string.Join(Environment.NewLine,
                results.Errors.Cast<CompilerError>().Select(x => x.ErrorText));
            MessageBox.Show(errors);
        }
    }
