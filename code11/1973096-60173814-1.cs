    public static async Task<string> UpdateProfile(Profile user, string serviceUrl)
    {
        var client = new RestClient(serviceUrl);
        var request = new RestRequest();
        request.Method = Method.POST;
        request.AddJsonBody(user);
        request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
        var response = await client.ExecuteAsync<Profile>(request);
        return response.Data.Address;            
    }
