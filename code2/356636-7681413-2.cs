     using (CSharpCodeProvider provider = new CSharpCodeProvider())
                {
                    parameters.ReferencedAssemblies.Add("System.dll");
                    parameters.ReferencedAssemblies.Add("System.Core.dll");
                  
                    CompilerResults results = provider.CompileAssemblyFromSource(parameters, sourceCode);
    
                }
