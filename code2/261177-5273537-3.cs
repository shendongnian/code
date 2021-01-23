    TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("http://tfs:8080"));
    var vcs = tfs.GetService<VersionControlServer>();
    var teamProjects = vcs.GetAllTeamProjects(true);
    IBuildServer buildServer = (IBuildServer)tfs.GetService(typeof(IBuildServer));
    foreach (TeamProject proj in teamProjects)
    {
        var defs = buildServer.QueryBuildDefinitions(proj.Name);
        System.Console.WriteLine(string.Format("Team Project: {0}", proj.Name));
        foreach(IBuildDefinition def in defs)
        {
            IBuildDetailSpec spec = buildServer.CreateBuildDetailSpec(proj.Name, def.Name);
            spec.MaxBuildsPerDefinition = 1;
            spec.QueryOrder = BuildQueryOrder.FinishTimeDescending;
            var builds = buildServer.QueryBuilds(spec);
            if (builds.Builds.Length > 0)
            {
                var buildDetail = builds.Builds[0];
                System.Console.WriteLine(string.Format("   {0} - {1} - {2}", def.Name, buildDetail.Status.ToString(), buildDetail.FinishTime));
            }                
        }
        System.Console.WriteLine();
    }
