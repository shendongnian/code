    using System;
    using System.IO;
    using System.CodeDom.Compiler;
    using System.Reflection;
    using Microsoft.CSharp;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                //set up the compiler
                CSharpCodeProvider csCompiler = new CSharpCodeProvider();
    
                CompilerParameters compilerParameters = new CompilerParameters();
                compilerParameters.GenerateInMemory = true;
                compilerParameters.GenerateExecutable = false;
                compilerParameters.ReferencedAssemblies.Add("System.dll");
    
                var definition = File.ReadAllText("./IDog.cs") +
    @"public class Dog : ConsoleApplication1.IDog
    {
        public void Bark()
        {
            System.Console.WriteLine(""BowWoW"");
        }
    }";
                CompilerResults results = csCompiler.CompileAssemblyFromSource(compilerParameters,
                    new string[1] { definition });
    
                dynamic dog = null;
                if (results.Errors.Count == 0)
                {
                    Assembly assembly = results.CompiledAssembly;
    //              Type idog = assembly.GetType("ConsoleApplication1.IDog");
                    dog = assembly.CreateInstance("Dog");
                } else {
                    Console.WriteLine("Has Errors");
                    foreach(CompilerError err in results.Errors){
                        Console.WriteLine(err.ErrorText);
                    }
                }
                if (dog != null){
                    dog.Bark();
                } else {
                    System.Console.WriteLine("null");
                }
            }
        }
    }
