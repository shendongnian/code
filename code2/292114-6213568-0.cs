    ...
    using System.Reflection;
    using System.CodeDom.Compiler;
    ...
    
    namespace YourNameSpace
    {
      public interface IRunner
      {
        void Run();
      }
    
      public class Program
      {
        static Main(string[] args)
        {
          if(args.Length == 1)
          {
            Assembly compiledScript = CompileCode(args[0]);
            if(compiledScript != null)
              RunScript(compiledScript);
          }
        }
    
        private Assembly CompileCode(string code)
        {
          Microsoft.CSharp.CSharpCodeProvider csProvider = new 
    Microsoft.CSharp.CSharpCodeProvider();
    
          CompilerParameters options = new CompilerParameters();
          options.GenerateExecutable = false;
          options.GenerateInMemory = true;
    
          // Add the namespaces needed for your code
          options.ReferencedAssemblies.Add("System");
          options.ReferencedAssemblies.Add("System.IO");
          options.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
    
          // Compile the code
          CompilerResults result;
          result = csProvider.CompileAssemblyFromSource(options, code);
    
          if (result.Errors.HasErrors)
          {
            // TODO: Output the errors
            return null;
          }
    
          if (result.Errors.HasWarnings)
          {
            // TODO: output warnings
          }
    
          return result.CompiledAssembly;
        }
    
        private void RunScript(Assembly script)
        {
          foreach (Type type in script.GetExportedTypes())
          {
            foreach (Type iface in type.GetInterfaces())
            {
              if (iface == typeof(YourNameSpace.Runner))
              {
                ConstructorInfo constructor = type.GetConstructor(System.Type.EmptyTypes);
                  if (constructor != null && constructor.IsPublic)
                  {
                    YourNameSpace.IRunner scriptObject = constructor.Invoke(null) as 
    YourNameSpace.IRunner;
    
                    if (scriptObject != null)
                    {
                      scriptObject.Run();
                    }
                    else
                    {
                      // TODO: Unable to create the object
                    }
                  }
                  else
                  {
                    // TODO: Not implementing IRunner
                  }
                }
              }
            }
          }
      }
    }
