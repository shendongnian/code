    var catalog = new AggregateCatalog();
            var files = Directory.GetFiles("Parent Directory", "*.dll", SearchOption.AllDirectories);
            foreach (var dllFile in files)
            {
                try
                {
                    var assembly = Assembly.LoadFile(dllFile);
                    var assemblyCatalog = new AssemblyCatalog(assembly);
                    catalog.Catalogs.Add(assemblyCatalog);
                }
                catch (Exception e)
                {
                   // this happens if the given dll file is not  a .NET framework file or corrupted.
                  
                }
            }`
