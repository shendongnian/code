    [WebInvoke(UriTemplate = "/{userName}/?key={key}&machineName={machineName}", Method = "PUT")]
    public HttpResponseMessage<SomeStuffPutResponse> PutSomeStuff(string userName, string key, string machineName, HttpRequestMessage request)
    {
         string theTextToPut = request.Content.ReadAsString();
    }
