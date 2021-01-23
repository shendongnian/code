    static void Main(string[] args)
    {
      // Run the method with a few test values
      GetAssemblyDetail("System.Data"); // This should be in the GAC
      GetAssemblyDetail("YourAssemblyName");  // This might be in the GAC
      GetAssemblyDetail("ImaginaryAssembly"); // This just plain doesn't exist
    }
    private static DateTime? GetAssemblyDetail(string assemblyName)
    {
      Assembly a;
      a = Assembly.LoadWithPartialName(assemblyName);
      if (a != null)
      {
        Console.WriteLine("'{0}' is in GAC? {1}", assemblyName, a.GlobalAssemblyCache);
        FileInfo fi = new FileInfo(a.Location);
        Console.WriteLine("'{0}' Modified: {1}", assemblyName, fi.LastWriteTime);
        return fi.LastWriteTime;
      }
      else
      {
        Console.WriteLine("Assembly '{0}' not found", assemblyName);
        return null;
      }
    }
