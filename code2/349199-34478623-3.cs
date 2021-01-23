    #if DEBUG
    using Windows.Storage;
    #endif
        // ...
        IEnumerable<string> assemblyNames;
    #if DEBUG
        assemblyNames = Windows.ApplicationModel.Package.Current.InstalledLocation.GetFilesAsync().AsTask().Result
            .Where(file => file.FileType == ".dll" && file.Name.Contains("Business"))
            .Select(file => file.Name.Substring(0, file.Name.Length - file.FileType.Length));
    #else
        assemblyNames = new[] { "California.Business", "Colorado.Business" };
    #endif
        foreach (var name in assemblyNames)
        {
            var assembly = Assembly.Load(new AssemblyName() { Name = name });
            
            // Load required types.
            // ...
        
        }
