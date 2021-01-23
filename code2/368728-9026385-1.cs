    public static void ValidateAllResourceTypes(this WebApiConfiguration config, string assemblyFilter = "MyCompany*.dll")
    {
        var path = Path.GetDirectoryName((new Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
        var dc = new DirectoryCatalog(path, assemblyFilter);
        var assemblies = dc.LoadedFiles.Select(Assembly.LoadFrom).ToList();
        assemblies.ForEach(assembly =>
        {
            var resourceTypes = assembly.GetTypes()
                .Where(t => t.Namespace != null && t.Namespace.EndsWith("Resources"));
            foreach (var resourceType in resourceTypes)
            {
                var configType = typeof(Extensions);
                var mi = configType.GetMethod("ModelValidationFor");
                var mi2 = mi.MakeGenericMethod(resourceType);
                mi2.Invoke(null, new object[] { config });
            }
        });            
    }
