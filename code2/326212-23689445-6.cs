       1:  [Serializable]
       2:  public class AssemblyLoader : MarshalByRefObject
       3:  {
       4:      private string ApplicationBase { get; set; }
       5:   
       6:      public AssemblyLoader()
       7:      {
       8:          ApplicationBase = AppDomain.CurrentDomain.SetupInformation.PrivateBinPath;
       9:          AppDomain.CurrentDomain.AssemblyResolve += Resolve;
      10:      }
      11:   
      12:      private Assembly Resolve(object sender, ResolveEventArgs args)
      13:      {
      14:          AssemblyName assemblyName = new AssemblyName(args.Name);
      15:          string fileName = string.Format("{0}.dll", assemblyName.Name);
      16:          return Assembly.LoadFile(Path.Combine(ApplicationBase, fileName));
      17:      }
      18:  }
 
