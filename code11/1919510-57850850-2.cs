    public static string GetProjectPath(Type startupClass)
    {
        var assembly = startupClass.GetTypeInfo().Assembly;
        var projectName = assembly.GetName().Name;
        var applicationBasePath = AppContext.BaseDirectory;
        var directoryInfo = new DirectoryInfo(applicationBasePath);
        do
        {
           directoryInfo = directoryInfo.Parent;
    
           var projectDirectoryInfo = new DirectoryInfo(directoryInfo.FullName);
           if (projectDirectoryInfo.Exists)
           {
              var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
              if (projectFileInfo.Exists)
              {  
                  return Path.Combine(projectDirectoryInfo.FullName, projectName);
              }
           }
        } while (directoryInfo.Parent != null);
    }
