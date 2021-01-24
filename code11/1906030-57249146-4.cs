    connection = new TfsTeamProjectCollection(new Uri("azure devops url"));
    connection.Authenticate();
    var = versionControl = connection .GetService<VersionControlServer>();
    var worksapce = versionControl.GetWorkspace("local-path-of-the-workspace");
    // Do the "Get Latest":
    workspace.Get();
