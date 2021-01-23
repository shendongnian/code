     1:  string applicationBase = Path.GetDirectoryName(interOperabilityPackageType.AssemblyDescription.AssemblyPath);
       2:  AppDomainSetup setup = new AppDomainSetup
       3:  {
       4:      ApplicationName = name,
       5:      ApplicationBase = applicationBase,
       6:      PrivateBinPath = AppDomain.CurrentDomain.BaseDirectory,
       7:      PrivateBinPathProbe = AppDomain.CurrentDomain.BaseDirectory,
       8:      ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile
       9:  };
      10:   
      11:  Evidence evidence = new Evidence(AppDomain.CurrentDomain.Evidence);
      12:  AppDomain domain = AppDomain.CreateDomain(name, evidence, setup);
      13:  domain.Load(File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Host.AssemblyLoader.dll")));
      14:  domain.AssemblyResolve += new AssemblyLoader(AppDomain.CurrentDomain.BaseDirectory).Handle;
 
