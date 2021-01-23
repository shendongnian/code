    private static void SetupResolvingAdditionalThirdPartyDlls()
    {
      AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblies;
    }
    
    private static Assembly ResolveAssemblies(object sender, ResolveEventArgs args)
    {
      Assembly assembly = null;
      bool foundAssembly = false;
    
      Console.DebugFormat("Received request for the following dll {0}", args.Name);
      int idx = args.Name.IndexOf(',');
      if (idx > 0)
      {
        string partialName = args.Name.Substring(0, idx);
        string dllName = partialName + ".dll";
        string exeName = partialName + ".exe";
    
        string searchDirectory = "locationOfDirectoryToSearch";
        // Add other directories that you want to search here
    
        List<string> directorySearch = new List<string>
        {
          CombinePath(searchDirectory, dllName),
          CombinePath(searchDirectory, exeName),
          // Include the other directories here to this list adding both the dll and exe.
        };
    
        foreach (string fileName in directorySearch)
        {
          if (File.Exists(fileName))
          {
            Console.DebugFormat("Found dll {0} at {1}", args.Name, fileName);
            foundAssembly = true;
            assembly = Assembly.LoadFrom(fileName);
            break;
          }
        }
    
        if (assembly == null)
        {
          if (!foundAssembly)
          {
            foreach (string fileName in directorySearch)
            {
              Console.DebugFormat("Could not find dll {0} in any search path used {1}", args.Name, fileName);
            }
          }
          else
          {
            Console.DebugFormat("Could not load dll {0}", args.Name);
          }
        }
      }
    
      return assembly;
    }
