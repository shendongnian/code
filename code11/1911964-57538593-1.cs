        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        private static Assembly CurrentDomain_AssemblyResolve(object sender, 
            ResolveEventArgs args)
        {
            if (new AssemblyName(args.Name).Name == "MyAssembly")
                return Assembly.LoadFrom(
                    Path.Combine(Application.StartupPath, "MyAssembly2.dll"));
            throw new Exception();
        }
