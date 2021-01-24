    public void WhateverIsCalledOnce()
    {
        var roken = conn.Query<Token>("select * from Token").First();
        _client = new RestClient("url").UseNewtonsoftJson();
        _client.Authenticator = new JwtAuthenticator(token.access_token);
    }
    
    public async Task CallRemoteServer()
    {
        var data = await _connection.GetDataFromDb("query");
        var request = new RestRequest("/api/v/DataToBeSent")
            .AddJsonBody(data);
        var result = await _client.PostAsync<DataToBeReturned>(request);
    }
