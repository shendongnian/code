    protected static IRestResponse SendRequest<T>(string baseUrl, string requestUrl, T data)
    {
        var restClient = new RestClient(baseUrl);
        var request = new RestRequest(requestUrl, Method.POST);
        request.RequestFormat = DataFormat.Json;
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
        request.AddParameter("application/json", json, ParameterType.RequestBody); // <-- Here
        var result = restClient.Execute(request);
        return result;
    }
    
    public static IRestResponse SendEmail()
    {
        // Call The Function
        var result = SendRequest(baseUrl, urlPageToHit, emailReceiptDto);
        return result;
    }
