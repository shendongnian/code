     1:  [Serializable]
       2:  public class AssemblyLoader
       3:  {
       4:      private string ApplicationBase { get; set; }
       5:   
       6:      public AssemblyLoader(string applicationBase)
       7:      {
       8:          ApplicationBase = applicationBase;
       9:      }
      10:   
      11:      public Assembly Resolve(object sender, ResolveEventArgs args)
      12:      {
      13:          AssemblyName assemblyName = new AssemblyName(args.Name);
      14:          string fileName = string.Format("{0}.dll", assemblyName.Name);
      15:          return Assembly.LoadFile(Path.Combine(ApplicationBase, fileName));
      16:      }
      17:  }
