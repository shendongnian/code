    static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                string assemblyFullName;
    
                System.Reflection.AssemblyName assemblyName;
    
                assemblyName = new System.Reflection.AssemblyName(args.Name);
                assemblyFullName = System.IO.Path.Combine(
                    System.IO.Path.Combine(
                        System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), <You folder>), assemblyName.Name + ".dll");
    
                if (System.IO.File.Exists(assemblyFullName))
                    return System.Reflection.Assembly.LoadFile(assemblyFullName);
                else
                    return null;
            }
