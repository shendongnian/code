    ...
    foreach (FileInfo file in dirInfo.GetFiles())
    {
    ...
      try
      {
        Assembly ass = Assembly.LoadFrom(file.FullName);
    ...
      catch (Exception)
      {
        // Ignore all errors caught due to the .NET framework not being able to load an assembly.
        // Not all qualifying files in the specified directories really are valid .NET assemblies.
      }
    ...
