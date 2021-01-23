    Assembly ResolveAssemblyReference(object sender, ResolveEventArgs args)
    {
        // Obtain information about the requested assembly
        AssemblyName targetAssemblyName = new AssemblyName(args.Name);
        string targetAssemblyFileName = targetAssemblyName.Name + ".dll";
        // Handle satellite assembly load requests. Note that prior to .NET 4.0, satellite assemblies didn't get
        // passed to AssemblyResolve handlers. When this was changed, there is a specific guarantee that if null is
        // returned, normal load procedures will be followed for the satellite assembly, IE, it will be located and
        // loaded in the same manner as if this event handler wasn't registered. This isn't sufficient for us
        // though, as the normal load behaviour doesn't correctly locate satellite assemblies where the owning
        // assembly has been loaded using Assembly.LoadFile where the assembly is located in a different folder to
        // the process assembly. We handle that here by performing the satellite assembly search process ourselves.
        // Also note that satellite assemblies are formally documented as requiring the file name extension of
        // ".resources.dll", so detecting satellite assembly load requests by comparing with this known string is a
        // valid approach.
        if (targetAssemblyFileName.EndsWith(".resources.dll"))
        {
            // Retrieve the owning assembly which is requesting the satellite assembly
            string owningAssemblyName = targetAssemblyFileName.Replace(".resources.dll", ".dll");
            Assembly owningAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((x) => x.Location.EndsWith(owningAssemblyName));
            if (owningAssembly == null)
            {
                return null;
            }
            // Retrieve the directory containing the owning assembly
            string owningAssemblyDirectory = Path.GetDirectoryName(owningAssembly.Location);
            // Search for the required satellite assembly in resource subdirectories, and load it if found.
            CultureInfo searchCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            while (searchCulture != CultureInfo.InvariantCulture)
            {
                string resourceAssemblyPath = Path.Combine(owningAssemblyDirectory, searchCulture.Name, targetAssemblyFileName);
                if (File.Exists(resourceAssemblyPath))
                {
                    Assembly resourceAssembly = LoadAssembly(resourceAssemblyPath);
                    if (resourceAssembly != null)
                    {
                        return resourceAssembly;
                    }
                }
                searchCulture = searchCulture.Parent;
            }
            return null;
        }
        // If the target assembly exists in the same directory as the requesting assembly, attempt to load it now.
        string requestingAssemblyPath = (args.RequestingAssembly != null) ? args.RequestingAssembly.Location : String.Empty;
        if (!String.IsNullOrEmpty(requestingAssemblyPath))
        {
            string callingAssemblyDirectory = Path.GetDirectoryName(requestingAssemblyPath);
            string targetAssemblyInCallingDirectoryPath = Path.Combine(callingAssemblyDirectory, targetAssemblyFileName);
            if (File.Exists(targetAssemblyInCallingDirectoryPath))
            {
                try
                {
                    return LoadAssembly(targetAssemblyInCallingDirectoryPath);
                }
                catch (Exception ex)
                {
                    // Log an error
                    return null;
                }
            }
        }
        // If the target assembly exists in the same directory as the process executable, attempt to load it now.
        string processDirectory = _processAssemblyDirectoryPath;
        string targetAssemblyInProcessDirectoryPath = Path.Combine(processDirectory, targetAssemblyFileName);
        if (File.Exists(targetAssemblyInProcessDirectoryPath))
        {
            try
            {
                return LoadAssembly(targetAssemblyInProcessDirectoryPath);
            }
            catch (Exception ex)
            {
                // Log an error
                return null;
            }
        }
        // Build a list of all assemblies with the requested name in the defined list of assembly search paths
        Dictionary<string, AssemblyName> assemblyVersionInfo = new Dictionary<string, AssemblyName>();
        foreach (string assemblyDir in _assemblySearchPaths)
        {
            // If the target assembly doesn't exist in this path, skip it.
            string assemblyPath = Path.Combine(assemblyDir, targetAssemblyFileName);
            if (!File.Exists(assemblyPath))
            {
                continue;
            }
            // Attempt to retrieve detailed information on the name and version of the target assembly
            AssemblyName matchAssemblyName;
            try
            {
                matchAssemblyName = AssemblyName.GetAssemblyName(assemblyPath);
            }
            catch (Exception)
            {
                continue;
            }
            // Add this assembly to the list of possible target assemblies
            assemblyVersionInfo.Add(assemblyPath, matchAssemblyName);
        }
        // Look for an exact match of the target version
        string matchAssemblyPath = assemblyVersionInfo.Where((x) => x.Value == targetAssemblyName).Select((x) => x.Key).FirstOrDefault();
        if (matchAssemblyPath == null)
        {
            // If no exact target version match exists, look for the highest available version.
            Dictionary<string, AssemblyName> assemblyVersionInfoOrdered = assemblyVersionInfo.OrderByDescending((x) => x.Value.Version).ToDictionary((x) => x.Key, (x) => x.Value);
            matchAssemblyPath = assemblyVersionInfoOrdered.Select((x) => x.Key).FirstOrDefault();
        }
        // If no matching assembly was found, log an error, and abort any further processing.
        if (matchAssemblyPath == null)
        {
            return null;
        }
        // If the target assembly is already loaded, return the existing assembly instance.
        Assembly loadedAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((x) => String.Equals(x.Location, matchAssemblyPath, StringComparison.OrdinalIgnoreCase));
        if (loadedAssembly != null)
        {
            return loadedAssembly;
        }
        // Attempt to load the target assembly
        try
        {
            return LoadAssembly(matchAssemblyPath);
        }
        catch (Exception ex)
        {
            // Log an error
        }
        return null;
    }
