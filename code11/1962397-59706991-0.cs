    private IRestResponse CallBox(string url, Method method, KeyValuePair<string, string>[] parameters = null, bool isUpload = false) {
        parameters = parameters ?? new KeyValuePair<string, string>[] { }; 
    
        RestClient client = new RestClient(url);
        RestRequest request = new RestRequest(method);
        foreach (KeyValuePair<string, string> param in parameters) {
            request.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
        }
        request.AddHeader("content-type", "multipart/form-data; boundary=-----------------------------28947758029299");
        IRestResponse response = client.Execute(request);
        return response;
    }
