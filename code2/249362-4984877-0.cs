        AppDomain.CurrentDomain.AssemblyResolve+= AssemblyResolve;
        public Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
             //try to get locally
             //try to download
             return assembly;
        }
