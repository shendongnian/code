      public static string GetExternalToolsExecutablePath(string externalAssemblyName)
        {
            try
            {
                var assemblyLocation = Assembly.GetEntryAssembly().Location;
                var directories = Path.GetDirectoryName(assemblyLocation);
                if (directories != null && Directory.Exists(directories))
                {
                    var dirInfo = new DirectoryInfo(directories);
                    var executable = dirInfo.GetFiles(externalAssemblyName, SearchOption.AllDirectories)
                        .Select(a => a.FullName).FirstOrDefault();
                    return !string.IsNullOrEmpty(executable) ? executable : null;
                }
                return null;
            }
            catch (Exception e)
            {
               
                return null;
            }
        }
