    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    using System.Reflection;
    namespace CodeCompilerTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
                CompilerParameters parameters = new CompilerParameters();
                //parameters.GenerateExecutable = false;
                parameters.GenerateInMemory = true;
                //parameters.OutputAssembly = "Output.dll";
                string SourceString = @"
                                       using System;
                                       using System.Collections.Generic;
                                       using System.Text;
                                       namespace testone 
                                       {
                                            public class myclass
                                            {
                                                public double testd(double a, double b)
                                                { 
                                                    return a+b;
                                                } 
                                            } 
                                        }";
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, SourceString);
                if (results.Errors.Count > 0)
                {
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        Console.WriteLine("Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";");
                    }
                    Console.ReadLine();
                }
                Assembly mAssembly = results.CompiledAssembly;
                Type scripttype = mAssembly.GetTypes()[0];
                Object myObject = Activator.CreateInstance(scripttype);
                double  rsltd = 0.0;
                Object[] argin = { 5.0, 8.0 };
                rsltd  =(double) scripttype.GetMethod("testd").Invoke(myObject,argin);
              //  object rslt = new object();
               // rslt = scripttype.InvokeMember("testd", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, null);
           Console.WriteLine(rsltd.ToString());
           Console.ReadLine();
            }
        }
    }
