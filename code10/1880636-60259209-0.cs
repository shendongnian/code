C#
WebProxy proxy = new WebProxy("http://< yourproxy.com >:< port number >", true, new List< string >().ToArray(), new NetworkCredential { Domain = "< domain >", UserName = "< username >", Password = "< password >" });
and then
C#
CosmosClient cosmosClient = new CosmosClient(< EndpointUri >, < PrimaryKey >, new CosmosClientOptions { ConnectionMode = ConnectionMode.Gateway, WebProxy = proxy });
Note that when using a Proxy, you will be forced to use ConnectionMode as Gateway.
