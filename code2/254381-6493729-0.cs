    var registerdCollection = RegisteredTfsConnections.GetProjectCollections().First();
    var projectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(registerdCollection);
    var versionControl = projectCollection.GetService<VersionControlServer>();
    
    var workspaceInfo = Workstation.Current.GetLocalWorkspaceInfo(_fileName);
    var server = new TeamFoundationServer(workspaceInfo.ServerUri.ToString());
    var workspace = workspaceInfo.GetWorkspace(server);
    
    workspace.PendEdit(fileName);
