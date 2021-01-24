    connection = new TfsTeamProjectCollection(new Uri("azure devops url"));
    connection.Authenticate();
    versionControl = tfs.GetService<VersionControlServer>();
    var worksapce = versionControl.GetWorkspace("local-path-of-the-workspace");
    // Do the "Get Latest":
    workspace.Get();
