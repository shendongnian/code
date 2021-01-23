    Version v = null;
    var a = Assembly.GetEntryAssembly() ?? GetWebEntryAssembly() ?? Assembly.GetExecutingAssembly();
    SnapshotVersion = FileVersionInfo.GetVersionInfo(a.Location).ProductVersion;
    if (ApplicationDeployment.IsNetworkDeployed)
    {
        var d = ApplicationDeployment.CurrentDeployment;
        v = d.CurrentVersion;
        v = new Version(v.Major, v.Minor, v.Revision);
    }
    else
        v = a.GetName().Version;
    if (v != null)
        version = string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
