    public Assembly Resolver(object sender, ResolveEventArgs args)
            {
                lock (this)
                {
                    Assembly assembly;
                    AssemblyName askedAssembly = new AssemblyName(args.Name);
    
                    string[] fields = args.Name.Split(',');
                    string name = fields[0];
                    string culture = fields[2];
                    // failing to ignore queries for satellite resource assemblies or using [assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.MainAssembly)] 
                    // in AssemblyInfo.cs will crash the program on non en-US based system cultures.
                    if (name.EndsWith(".resources") && !culture.EndsWith("neutral")) return null;
    
                    /* the actual assembly resolver */
                    ...
                }
          }
