    /// <summary>Searches all loaded assemblies in a project for the specified embedded resource text file.</summary>
    /// <returns>If the specified resource is found, its contents as a string, otherwise throws a DllNotFoundException.</returns>
    /// <exception cref="DllNotFoundException"></exception>
    public static string FetchAssemblyResourceFile(string name)
    {
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        int i = -1; while ((++i < assemblies.Length) && !Regex.IsMatch(name, "^(" + assemblies[i].ExtractName() + ")", RegexOptions.IgnoreCase)) ;
        if (i < assemblies.Length)
        {
            try {
                using (System.IO.Stream stream = assemblies[i].GetManifestResourceStream(name))
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                    return reader.ReadToEnd();
            }
            catch (Exception innerExc)
            {
                Exception result = new Exception("The requested resource (\"" + name + "\") was not found.");
                result.InnerException = innerExc;
                throw result;
            }
        }
        throw new DllNotFoundException("The requested assembly resource (\"" + name + "\") could not be found.");
    }
