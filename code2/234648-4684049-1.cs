    using (DdeClient client = new DdeClient(DDE_SERVER_NAME, dataField))
    {
        client.Connect();
    
        string data = client.Request("xyz", DDE_TIMEOUT);
    }
