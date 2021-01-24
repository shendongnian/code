    private IRestResponse CallBox(string url, Method method, KeyValuePair<string, string>[] parameters = null, bool isUpload = false) {
        parameters = parameters ?? new KeyValuePair<string, string>[] { }; 
    
        RestClient client = new RestClient(url);
        RestRequest request = new RestRequest(method);
        foreach (KeyValuePair<string, string> parameter in parameters) {
            request.AddParameter(parameter.Key, parameter.Value, ParameterType.GetOrPost);
        }
        request.AddHeader("content-type", "multipart/form-data; boundary=-----------------------------28947758029299");
        IRestResponse response = client.Execute(request);
        return response;
    }
