        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            //Build the path of the assembly from where it has to be loaded.				
            assemblyPath = System.IO.Path.Combine("your path", args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");
            assembly = Assembly.LoadFrom(assemblyPath);
            //Return the loaded assembly.
            return assembly;
        }
