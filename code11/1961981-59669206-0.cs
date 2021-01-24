    public static T Get<T>(string endpoint, params KeyValuePair[] parameters) where T : new()
    {
        var request = new RestRequest(endpoint);
        foreach (var parameter in parameters)
        {
            if (endpoint.Contains($"{{{parameter.Key}}}")
                request.AddUrlSegmentParameter(parameter.Key, parameter.Value);
            else
                request.AddQueryStringParameter(parameter.Key, parameter.Value);
        }
        var response = client.Get<T>(request);
        return response.Data;
    }
