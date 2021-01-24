    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        try
        {
            var assemblyName = args.Name.Split(',').First();
            if (!assemblyName.StartsWith("SharpDX"))
                return null;
            //Simply converts relative paths to full paths in order to
            //prevent getting the wrong path when the app is loaded from a
            //link or "Open with..." commands.
            var path = Other.AdjustPath(UserSettings.All.SharpDxLocationFolder ?? "");
            return Assembly.LoadFrom(System.IO.Path.Combine(path, $"{assemblyName}.dll"));
        }
        catch (Exception e)
        {
            LogWriter.Log(e, "Error loading assemblies");
            return null;
        }
    }
