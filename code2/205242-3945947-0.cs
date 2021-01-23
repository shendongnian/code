    // register to listen to all assembly resolving attempts:
     AppDomain currentDomain = AppDomain.CurrentDomain;
     currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    
    
     // Check whether the desired assembly is already loaded
     private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args) {
        string desiredAssmebly = args.Name;
        if (desiredAssembly.Equals("NameUsedToLoadMyAssembly")){
            return Assembly.LoadFrom(myAssemblyPath);
        }
        
        return null;
      }
