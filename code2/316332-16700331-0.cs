    //--begin example:
    
    
    public MyClass(){
    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    }
    
    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                foreach (var moduleDir in _moduleDirectories)
                {
                    var di = new DirectoryInfo(moduleDir);
                    var module = di.GetFiles().FirstOrDefault(i => i.Name == args.Name+".dll");
                    if (module != null)
                    {
                        return Assembly.LoadFrom(module.FullName);
                    }
                }
                return null;
            }
    
    
    
    //---end example
