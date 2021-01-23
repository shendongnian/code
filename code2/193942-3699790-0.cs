    Console.Write("Enter a path to write the list of interfaces to: ");
    string savePath = Console.ReadLine();
    var errors = new List<string>();
    using (var writer = new StreamWriter(savePath))
    {
        string dotNetPath = @"C:\Windows\Microsoft.NET\Framework";
        string[] dllFiles = Directory.GetFiles(dotNetPath, "*.dll", SearchOption.AllDirectories);
        foreach (string dllFilePath in dllFiles)
        {
            try
            {
                Assembly assembly = Assembly.LoadFile(dllFilePath);
                var interfaceTypes = assembly.GetTypes()
                    .Where(t => t.IsInterface);
                foreach (Type interfaceType in interfaceTypes)
                {
                    writer.WriteLine(interfaceType.FullName);
                    Console.WriteLine(interfaceType.FullName);
                }
            }
            catch
            {
                errors.Add(string.Format("Unable to load assembly '{0}'.", dllFilePath));
            }
        }
    }
    foreach (string err in errors)
    {
        Console.WriteLine(err);
    }
    Console.ReadLine();
