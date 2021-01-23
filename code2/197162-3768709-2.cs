    var rootPath = @"C:\MyRoot\Folder";
    var query = Directory.GetFiles(rootPath, "*.dll", SearchOption.AllDirectories)
                         .Select(fileName =>
                         {
                             try
                             {
                                 return Assembly.ReflectionOnlyLoadFrom(fileName);
                             }
                             catch
                             {
                                 return null;
                             }
                         })
                         .Where(assembly => assembly != null)
                         .Select(assembly => new
                         {
                             Version = assembly.GetName().Version.ToString(),
                             Name = assembly.GetName().Name
                         });
    foreach (var infos in query)
    {
        Console.WriteLine(infos.Name + "   " + infos.Version);
    }
