    using System;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    
    class Sample {
        static void Main(){
            CSharpCodeProvider csCompiler = new CSharpCodeProvider();
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.GenerateInMemory = true;
            compilerParameters.GenerateExecutable = false;
            string temp =
    @"static public class Eval {
        static public int calc() {
            int exp = $exp;
            return exp;
        }
    }";
            Console.Write("input expression: ");
            string equation = Console.ReadLine();
            Console.WriteLine("your equation is {0}", equation);
            temp = temp.Replace("$exp", equation);
            CompilerResults results = csCompiler.CompileAssemblyFromSource(compilerParameters,
                new string[1] { temp });
    
            if (results.Errors.Count == 0){
                Assembly assembly = results.CompiledAssembly;
                MethodInfo calc = assembly.GetType("Eval").GetMethod("calc");
                int answer = (int)calc.Invoke(null, null);
                Console.WriteLine("answer is {0}", answer);
            } else {
                Console.WriteLine("expression errors!");
            }
        }
    }
