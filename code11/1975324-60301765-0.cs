    public void Store(string _putUrl, string _url, string _clientId, string _clientSecret, HiveObject objToStore)
    {
        var hiveClient = new HiveClient(_url, _clientId, _clientSecret);
        hiveClient.CheckIfFileExists();
        string token = hiveClient.restToken;
        var restClient = new RestClient(_putUrl);
        var request = new RestRequest()
            .AddHeader("Authorization", token)
            .AddJsonBody(objToStore);
        var result = restClient.Put<Dictionary<string, string>>(request);
    } 
