    using Microsoft.CSharp;
    public class MyTemplate : IDisposable {
       private const string _SourceCodeTemplate = @"
    using System;
    public class {0} {{ // {{0}} Class name
    public {0} CreateInstance() 
    {{
    {0} instance;
    //... some codes here to create instance
    return instance;
    }}
    public {1} {2}() {{ // {{1}} method result, {{2}} method name
    {1} result;
    // some codes here for the result
    return result;
    }}
    }}";
    
      public T CallInstanceMethod<T>(string className, string callMethod, 
        string callMethodResult, 
        params object[] paramList) {
        string codes;
        // build codes dynamically
        codes = string.Format(_SourceCodeTemplate, className, 
                  callMethodResult, callMethod);
         CSharpCodeProvider codeProvider = new CSharpCodeProvider();
         CompilerParameters parameters = new CompilerParameters();
         parameters.GenerateExecutable = false;
         parameters.GenerateInMemory = true;
         parameters.IncludeDebugInformation = false;
     
         foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
         {
           parameters.ReferencedAssemblies.Add(asm.Location);
         }
         // compile the codes
         CompilerResults cr= codeProvider.CompileAssemblyFromSource(parameters, codes);
         var csInstance = cr.CompiledAssembly.CreateInstance(className);
         Type type = csInstance.GetType();
         var methodForInstance = type.GetMethod(callMethod);
         object value;
         value = _methodForInstance.Invoke(csInstance, paramList);
         return (T)value;
      }
    }
