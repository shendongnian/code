    var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(fileName);
    using (var server = new TfsTeamProjectCollection(workspaceInfo.ServerUri))
    {
        var workspace = workspaceInfo.GetWorkspace(server);    
        workspace.PendEdit(fileName);
    }
