    // set agent pool Id and project name
    int agentPoolId = 123456; 
    string teamProjectName = ".....";
    // _connection is of type VssConnection
    using (var taskAgentClient = _connection.GetClient<TaskAgentHttpClient>())
    using (var releaseClient = _connection.GetClient<ReleaseHttpClient2>())
    {
        // please note: agent pool Id != queue Id
        // agent pool id is used to get the build definitions
        // queue Id is used to get the release definitions
        TaskAgentPool agentPool = await taskAgentClient.GetAgentPoolAsync(agentPoolId);
        List<TaskAgentQueue> queues = await taskAgentClient.GetAgentQueuesByNamesAsync(teamProjectName, queueNames: new[] { agentPool.Name });
        TaskAgentQueue queue = queues.FirstOrDefault();
        List<ReleaseDefinition> definitions = await releaseClient.GetReleaseDefinitionsAsync(teamProjectName, string.Empty, ReleaseDefinitionExpands.Environments);
        foreach (ReleaseDefinition definition in definitions)
        {
            var fullDefinition = await releaseClient.GetReleaseDefinitionAsync(teamProjectName, definition.Id);
            bool hasReleasesWithPool = fullDefinition.Environments.SelectMany(GetDeploymentInputs)
                                                                  .Any(di => di.QueueId == queue.Id);
            if (hasReleasesWithPool)
            {
                Debug.WriteLine($"{definition.Name}");
            }
        }
    }
    private IEnumerable<DeploymentInput> GetDeploymentInputs(ReleaseDefinitionEnvironment environment)
    {
        return environment.DeployPhases.Select(dp => dp.GetDeploymentInput())
                                       .OfType<DeploymentInput>();
    }
