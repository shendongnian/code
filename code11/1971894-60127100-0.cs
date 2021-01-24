csharp
t.CallTest(); //where t is an instance of your class
and run it.
As I hinted in the comments, [Reflection][1] might be way easier to do. But for a second, let's imagine you need to keep pressing on and generate some fancy code that you will then need to run (which is where [LINQ Expression trees][2] might be a better answer, but never mind - suppose we're still sticking to CodeDom).
There are a couple of issues I see to overcome here:
1. The unit of compilation in CodeDom is assembly, I don't believe you can have assembly nested in a class. Therefore you need to define at least a namespace and a class (which you seem to have done already)
2. I also don't believe CodeDom allows you to [compile partial classes][3], therefore your generated code with direct references to `Test` will not compile even if you manage to overcome point #1
With the above in mind, I believe one option will be to basically have your generated code invoke reflection to obtain a reference to your desired method and invoke it dynamically (which kinda gets reduced to my suggestion #1):
csharp
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;
namespace ConsoleApp9
{
    public class MainTestClass
    {
        private void CallTest(string value) => Console.WriteLine($"CallTest({value})");
        public object OnMethodInvoke(string functionName, List<object> parameters)
        {
            if (functionName == "exec")
            {
                CSharpCodeProvider c = new CSharpCodeProvider();
                CompilerParameters cp = new CompilerParameters();
                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("ConsoleApp9.exe"); // note a reference to your main assembly here
                cp.CompilerOptions = "/t:library";
                cp.GenerateInMemory = true;
                StringBuilder sb = new StringBuilder("");
                sb.Append("using System;\n");
                sb.Append("using System.Reflection;\n");
                sb.Append("using ConsoleApp9;\n"); // reference your main assembly ConsoleApp9. this is my test console app 
                sb.Append("namespace ScriptStack.Dynamic\n");
                sb.Append("{\n");
                sb.Append("	public class Code\n");
                sb.Append(" {\n");
                sb.Append("		private MainTestClass t;\n"); // reference your 
                sb.Append("		public Code(MainTestClass t) { this.t = t; }\n"); // we're going to capture reference to calling MainTestClass instance and use it for reflection
                sb.Append("		public object EvalCode()\n");
                sb.Append("		{\n");
                sb.Append("			// this is a very standard method of invoking private methods. see this SO answer: https://stackoverflow.com/a/135482/12339804 \n");
                sb.Append("			var mi = typeof(MainTestClass).GetMethod(\"CallTest\", BindingFlags.NonPublic | BindingFlags.Instance);\n");
                sb.Append("			return mi.Invoke(t, new object[]{ \"" + (string)parameters[0] + "\" });\n"); //suppose you want to pass a string to your generated C# source.
                sb.Append("		}\n");
                sb.Append("	}\n");
                sb.Append("}\n");
                var cr = c.CompileAssemblyFromSource(cp, sb.ToString());
                if (cr.Errors.Count > 0) return null;
                var a = cr.CompiledAssembly;
                object o = a.CreateInstance("ScriptStack.Dynamic.Code", false, BindingFlags.Default, null, new object[] { this }, CultureInfo.InvariantCulture, null); //we have to opt for a way more overloaded CreateInstance method due to us requiring to pass a this into the Code class we're instantiating
                var mi = o.GetType().GetMethod("EvalCode");
                return mi.Invoke(o, null);
            }
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var t = new MainTestClass();
            t.OnMethodInvoke("exec", new List<object> { "parameter 1" });
            Console.ReadKey();
        }
    }
}
  [1]: https://stackoverflow.com/a/135482/12339804
  [2]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/expression-trees/
  [3]: https://stackoverflow.com/questions/2703439/codedom-compile-partial-class
