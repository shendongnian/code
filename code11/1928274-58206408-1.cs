    Audit.Core.Configuration.DataProvider = new MultiDataProvider(
    	new AuditDataProvider[]
    	{
    		new ElasticsearchDataProvider(_ => _
    			 .ConnectionSettings(new Uri(elasticUri))
    				.Index("sample-index")
    				.Id(ev => Guid.NewGuid())),
    		new UdpDataProvider()
    		{
    			RemoteAddress = IPAddress.Parse("127.0.0.1"),
    			RemotePort = 6060
    		}
    	}
    );
