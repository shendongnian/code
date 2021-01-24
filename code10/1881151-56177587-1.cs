    /// <summary>Searches all loaded assemblies in a project for the specified embedded resource text file.</summary>
    /// <returns>If the specified resource is found, its contents as a string, otherwise throws a DllNotFoundException.</returns>
    /// <exception cref="DllNotFoundException"></exception>
    public static string FetchAssemblyResourceFile(string name)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        int i = -1; while ((++i < assemblies.Length) && !Regex.IsMatch(name, "^(" + assemblies[i].ExtractName() + ")", RegexOptions.IgnoreCase)) ;
        if (i < assemblies.Length)
        {
            using (System.IO.Stream stream = assemblies[i].GetManifestResourceStream(name))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                return reader.ReadToEnd();
        }
        throw new DllNotFoundException("The requested assembly resource (\"" + name + "\") could not be found.");
    }
