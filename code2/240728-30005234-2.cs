    private string[] GetAssembly(string[] assemblyNames)
    {
        string [] locations = new string[assemblyNames.Length];
     
        for (int loop = 0; loop <= assemblyNames.Length - 1; loop++)       
        {
             locations[loop] = AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic && a.ManifestModule.Name == assemblyNames[loop]).Select(a => a.Location).FirstOrDefault();
        }
        return locations;
    }
