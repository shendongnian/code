    public IEnumerable<IQueuedBuild> getQueuedBuilds(TfsTeamProjectCollection tfsCollection, string teamProject)
    {
        // Get instance of build server service from TFS
        IBuildServer buildServer = tfsCollection.GetService<IBuildServer>();
        // Set up query
        IQueuedBuildSpec spec = buildServer.CreateBuildQueueSpec(teamProject);
        spec.Status = QueueStatus.Queued;
        // Execute query
        IQueuedBuildQueryResult result = buildServer.QueryQueuedBuilds(spec);
        // Array of queued builds will be in the result.QueuedBuilds property
        return result.QueuedBuilds;
    }
