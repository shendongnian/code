    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Net;
    using Microsoft.CSharp;
    using System.CodeDom.Compiler;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string test = "{{ \"BusinessOrg\", \"BusinessOrgID\", \"BusinessOrg\", \"BusinessOrgID\"}, { \"BusinessParameters\", \"BusinessOrgID\", \"BusinessOrg\", \"BusinessOrgID\"}}";
                string [,] a = GetArray(test);
    
                string test2 = "{{ \"BusinessOrg2\", \"BusinessOrgID2\", \"BusinessOrg2\", \"BusinessOrgID2\"}, { \"BusinessParameters\", \"BusinessOrgID\", \"BusinessOrg\", \"BusinessOrgID\"}}";
                string[,] b = GetArray(test2);
            }
    
            static string[,] GetArray(string source)
            {
                if (source == null)
                    throw new ArgumentNullException();
    
                string sourceCode = 
                @"namespace Sample
    {
        public class ArrayConverter
        {
            public string [,] GetArray()
            {
                string [,] s = "+source + ";" +
    @"            return s;
            }
        }
    }";
    
                 Dictionary<string, string> providerOptions = new Dictionary<string, string>
                    {
                        {"CompilerVersion", "v3.5"}
                    };
                CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);
    
                CompilerParameters compilerParams = new CompilerParameters
                    {GenerateInMemory = true,
                     GenerateExecutable = false};
    
                CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, sourceCode);
    
                if (results.Errors.Count != 0)
                    throw new Exception("Mission failed!");
    
                object o = results.CompiledAssembly.CreateInstance("Sample.ArrayConverter");
                MethodInfo mi = o.GetType().GetMethod("GetArray");
                return (string [,])mi.Invoke(o, null);
            }
        }
    }
