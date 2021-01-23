            static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                Assembly ayResult = null;
                string sShortAssemblyName = args.Name.Split(',')[0];
                Assembly[] ayAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly ayAssembly in ayAssemblies)
                {
                    if (sShortAssemblyName == ayAssembly.FullName.Split(',')[0])
                    {
                        ayResult = ayAssembly;
                        break;
                    }
                }
                return ayResult;
            }
    
            public Constructor()
            {
                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            }
