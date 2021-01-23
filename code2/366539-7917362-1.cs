    using (var stream = Assembly.GetExecutingAssembly().
        GetManifestResourceStream(resourceName)) 
    {
          Byte[] assemblyData = new Byte[stream.Length];
          stream.Read(assemblyData, 0, assemblyData.Length);
          return Assembly.Load(assemblyData);
    }
