    static void Main(string[] args)
    {
        string input = "This is a test";
        string method = "Mid(x, 2, 4)";  // 'x' represents the input value
        string output = Convert(method, input);
        Console.WriteLine("Result: " + output);
        Console.ReadLine();
    }
    // Convert input using given vbscript logic and return as output string
    static string Convert(string vbscript, string input)
    {
        var func = GetFunction(vbscript);
        return func(input);
    }
    // Create a function from a string of vbscript that can be applied
    static Func<string, string> GetFunction(string vbscript)
    {
        // generate simple code snippet to evaluate expression
        VBCodeProvider prov = new VBCodeProvider();
        CompilerResults results = prov.CompileAssemblyFromSource(
            new CompilerParameters(new[] { "System.Core.dll" }),
            @"
    Imports System
    Imports System.Linq.Expressions
    Imports Microsoft.VisualBasic
    Class MyConverter
    Public Shared Function Convert() As Expression(Of Func(Of String, String))
        return Function(x) " + vbscript + @"
    End Function
    End Class
    "
            );
        // make sure no errors occurred in the conversion process
        if (results.Errors.Count == 0)
        {
            // retrieve the newly prepared function by executing the code
            var expr = (Expression<Func<string, string>>)
                results.CompiledAssembly.GetType("MyConverter")
                    .GetMethod("Convert").Invoke(null, null);
            Func<string, string> func = expr.Compile();
            // create a compiled function ready to apply and return
            return func;
        }
        else
        {
            return null;
        }
    }
