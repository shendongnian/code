    public static void StartPipeline(string resourceGroup, string dataFactory, string pipeLineName, DataFactoryManagementClient client )
    {
       var pipeLine = client.Pipelines.Get(resourceGroup, dataFactory, pipeLineName);
       client.Pipelines.CreateRun(resourceGroup, dataFactory, pipeLineName);
    }
