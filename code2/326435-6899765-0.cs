    string clrVersion = System.Environment.Version.ToString();
    string dotNetVersion = Assembly
                          .GetExecutingAssembly()
                          .GetReferencedAssemblies()
                          .Where(x => x.Name == "mscorlib").First().Version.ToString();
                
