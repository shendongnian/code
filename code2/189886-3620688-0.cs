    using System.Reflection;
    
    static Program()
    {
        AppDomain.CurrentDomain.AssemblyResolve += delegate(object sender, ResolveEventArgs e)
        {
            AssemblyName requestedName = new AssemblyName(e.Name);
    
            if (requestedName.Name == "Office11Wrapper")
            {
                // Put code here to load whatever version of the assembly you actually have
    
                return Assembly.LoadFile("Office11Wrapper.DLL");
            }
            else
            {
                return null;
            }
        }
    }
