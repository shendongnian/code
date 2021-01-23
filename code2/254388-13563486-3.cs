    private const string tfsServer = @"http://tfsserver.org:8080/tfs";
    public void CheckOutFromTFS(string fileName)
    {
        using (TfsTeamProjectCollection pc = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(tfsServer)))        
        {
            if (pc != null)
            {
                WorkspaceInfo workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(fileName);
                if (null != workspaceInfo)
                {                   
                    Workspace workspace = workspaceInfo.GetWorkspace(pc);
                    workspace.PendEdit(fileName);
                }
            }
        }
        FileInfo fi = new FileInfo(fileName);
    }
