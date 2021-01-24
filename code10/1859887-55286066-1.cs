    public async Task<Response> GetFooBar(string id)
    {
        var client = new JsonServiceClient(BasePath) { 
            RequestFilter = req => req.Headers.Add(
                "X-FooBar-Key", DefaultHeader["X-FooBar-Key"])
        }
        try 
        {
            var response = await client.GetAsync<Response>($"/{id}");
            response.Id = id; // Why isn't this already in the response?
            return response;
        }
        catch (WebServiceException ex)
        {
            //Error Details
            //ex.StatusCode;
            //ex.ErrorCode;
            //ex.ErrorMessage;
        }
    }
