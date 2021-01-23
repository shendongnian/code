    AppDomain.CurrentDomain.AssemblyResolve += 
      new ResolveEventHandler(CurrentDomain_AssemblyResolve);
    private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender,
      ResolveEventArgs args)
        {
          string name = args.Name;
          //You can return null if you don't know how to load this assembly
          return Assembly.LoadFrom(SomeFunction(name));
        }
