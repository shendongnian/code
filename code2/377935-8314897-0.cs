    try
    {
    WorkspaceInfo wsi = Workstation.Current.GetLocalWorkspaceInfo(localFileName);
    TfsTeamProjectCollection tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(wsi.ServerUri);
    Workspace wr = wsi.GetWorkspace(tfs);
    string ret = wr.TryGetServerItemForLocalItem(localFileName);
    return ret;
    }
    catch
    {
      return null;
    } 
