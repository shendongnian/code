    public AggregateCatalog ForAssembliesInDirectory(string directory, string pattern)
            {
    			IList<ComposablePartCatalog> _catalogs = new List<ComposablePartCatalog>();
    		
                var dir = new DirectoryInfo(directory);
                Assembly assembly;
                foreach (var file in dir.GetFiles(pattern))
                {
                    assembly = Assembly.LoadFile(file.FullName);            
                    _catalogs.Add(new AssemblyCatalog(assembly));
                }
    
                return new AggregateCatalog(_catalogs);
            }
