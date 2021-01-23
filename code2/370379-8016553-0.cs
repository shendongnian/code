    var version = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute),
                                                false);
                          .Cast<AssemblyFileVersionAttribute>()
                          .Select(attr => attr.Version)
                          .FirstOrDefault();
    if (version != null)
    {
        // Got the version number...
    }
