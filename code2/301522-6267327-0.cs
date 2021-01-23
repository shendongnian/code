    var expression = "(true and false) or (true or false)";
    
    var helper = "" + 
        "using System; " + 
        "public class Expression {{ public bool Eval() {{ return {0}; }} }}";
    
    var replaced = expression.Replace("and", "&&").Replace("or", "||");
    
    var references = new string[] { "System.dll" };
    var parameters = new CompilerParameters(references, "Test.dll");
    var compiler = new CSharpCodeProvider();
    
    
    var results = compiler.CompileAssemblyFromSource(
        parameters, 
        String.Format(helper, replaced));
    
    dynamic exp = Activator.CreateInstance(
        results.CompiledAssembly.GetType("Expression"));
    
    Console.WriteLine(exp.Eval());
