    private void ConfigureApplicationParts(ApplicationPartManager apm)
        {
            var rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    
            var assemblyFiles = Directory.GetFiles(rootPath , "*.dll");
            foreach (var assemblyFile in assemblyFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFile(assemblyFile);
                    if (assemblyFile.EndsWith(this.GetType().Namespace + ".Views.dll") || assemblyFile.EndsWith(this.GetType().Namespace + ".dll"))
                        continue;
                    else if (assemblyFile.EndsWith(".Views.dll"))
                        apm.ApplicationParts.Add(new CompiledRazorAssemblyPart(assembly));
                    else
                        apm.ApplicationParts.Add(new AssemblyPart(assembly));
                }
                catch (Exception e) { }
            }
        }
