    public static MyWcfClientType GetWcFClient(string hostName)
    {
        MyWcfClientType client = new MyWcfClientType();
    
        // Build a new URI object using the given hostname
        UriBuilder uriBld = new UriBuilder(client.Endpoint.Address.Uri);
        uriBld.Host = hostName;
        
        // Set a new endpoint address into the client
        client.Endpoint.Address = new EndpointAddress(uriBld.ToString());
        return client;
    }
