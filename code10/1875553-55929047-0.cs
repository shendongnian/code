    using System;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
        
    public class TestApp
    {
        public static void Main(string[] args)
        {
            CSharpCodeProvider provider = new CSharpCodeProvider();
    
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;
            parameters.OutputAssembly = "MyImpl";
            parameters.ReferencedAssemblies.Add(typeof(IInterface).Assembly.Location);
    
            CompilerResults results = provider.CompileAssemblyFromSource(
                parameters,
                @"
                        public class MyImpl : IInterface
                        {
                            public string GetName()
                            {
                                return ""test"";
                            }
                        }
                    "
            );
    
            var myImplType = results.CompiledAssembly.GetType("MyImpl");
            IInterface impl = (IInterface)Activator.CreateInstance(myImplType);
    
    
            System.Diagnostics.Debug.WriteLine(impl.GetName());
        }
    }
    
    public interface IInterface
    {
        string GetName();
    
    }
