    try
    {
    Uri serverUri = new Uri(uri);
    TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(serverUri);
    VersionControlServer vcs = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));   
    Workstation.Current.EnsureUpdateWorkspaceInfoCache(vcs, Environment.UserName);
    Workspace wr = vcs.GetWorkspace(Environment.MachineName, Environment.UserName);
    string ret=wr.TryGetLocalItemForServerItem(serverFileName);
    return ret;
    }
    catch
    {
      return null;
    }
