    public static class AssemblyResolver { 
        static AssemblyResolver() { 
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(delegate(object sender,  ResolveEventArgs args) {
                return Assembly.LoadFrom(...); 
            }); 
        }  
    } 
