    /// <summary>
      ///  get local sql server instance names from registry, search both WOW64 and WOW3264 hives
      /// </summary>
      /// <returns>a list of local sql server instance names</returns>
      public static IList<string> GetLocalSqlServerInstanceNames()
      {
         RegistryValueDataReader registryValueDataReader = new RegistryValueDataReader();
         string[] instances64Bit = registryValueDataReader.ReadRegistryValueData(RegistryHive.Wow64,
                                                                                 Registry.LocalMachine,
                                                                                 @"SOFTWARE\Microsoft\Microsoft SQL Server",
                                                                                 "InstalledInstances");
         string[] instances32Bit = registryValueDataReader.ReadRegistryValueData(RegistryHive.Wow6432,
                                                                                 Registry.LocalMachine,
                                                                                 @"SOFTWARE\Microsoft\Microsoft SQL Server",
                                                                                 "InstalledInstances");
         FormatLocalSqlInstanceNames(ref instances64Bit);
         FormatLocalSqlInstanceNames(ref instances32Bit);
         IList<string> localInstanceNames = new List<string>(instances64Bit);
         localInstanceNames = localInstanceNames.Union(instances32Bit).ToList();
         return localInstanceNames;
      }
======================================
    public enum RegistryHive
