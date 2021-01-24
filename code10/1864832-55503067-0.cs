    public static Stream GetEmbeddedResourceStream(Assembly assembly, string resourceFileName)
    {
      var resourcePaths = assembly.GetManifestResourceNames()
        .Where(x => x.EndsWith(resourceFileName, StringComparison.OrdinalIgnoreCase))
        .ToList();
      if (resourcePaths.Count == 1)
      {
        return assembly.GetManifestResourceStream(resourcePaths.Single());
      }
      return null;
    }
    
    var nlogConfigFile = GetEmbeddedResourceStream(myAssembly, "NLog.config");
    if (nlogConfigFile != null)
    {
        var xmlReader = System.Xml.XmlReader.Create(nlogConfigFile);
        NLog.LogManager.Configuration = new XmlLoggingConfiguration(xmlReader, null);
    }
