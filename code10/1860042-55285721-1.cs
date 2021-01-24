    public IRestResponse Some_Method(string s = "")
    {
        RestClient client = new RestClient("http://some-api-url/v1.9/");
        RestRequest request = new RestRequest("someMethod/{id}");
        request.AddParameter("id", s, ParameterType.UrlSegment);
        var response = client.Execute(request);
        return response;
