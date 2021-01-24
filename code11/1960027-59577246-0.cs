    public HttpResponseMessage Get()
    {
        // initialize your MyObject instance
        var cls = new MyObject
        {
            name = "AAAAA"
        };
    
        var stringified = JsonConvert.SerializeObject(cls);
        var response = Request.CreateResponse(HttpStatusCode.OK);
        // explicitly return a stringified JSON object
        response.Content = new StringContent(stringified, Encoding.UTF8, "application/json");
        return response;
    }
