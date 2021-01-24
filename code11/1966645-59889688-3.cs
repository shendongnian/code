    var plugins = new ElasticsearchPlugins(ElasticsearchPlugin.RepositoryAzure, ElasticsearchPlugin.IngestAttachment);
    var config = new EphemeralClusterConfiguration("7.5.1", ClusterFeatures.XPack, plugins, numberOfNodes: 1);
    using (var cluster = new EphemeralCluster(config))
    {
    	cluster.Start();
    
    	var nodes = cluster.NodesUris();
    	var connectionPool = new StaticConnectionPool(nodes);
    	var settings = new ConnectionSettings(connectionPool).EnableDebugMode();
    	var client = new ElasticClient(settings);
    				
    	Console.Write(client.CatPlugins().DebugInformation);
    }
