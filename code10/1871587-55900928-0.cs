    using Windows.ApplicationModel;
    
    public static string GetAppVersion()
    {
      Package package = Package.Current;
      PackageId packageId = package.Id;
      PackageVersion version = packageId.Version;
    
      return string.Format("{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
    }
