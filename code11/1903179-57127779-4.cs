    public static async Task<HttpResponseMessage> Run(HttpRequest req, ILogger log)
    {
        dynamic data = await req.Content.ReadAsAsync<object>();
    
        // ..
        
        var result = new
        {
            a = matchedList,
            b = unmatchedList
        };
        
        /* The mediaType-param with value 'JsonMediaTypeFormatter.DefaultMediaType' can be omitted. */
        return req.CreateResponse(HttpStatusCode.OK, result, JsonMediaTypeFormatter.DefaultMediaType);
      } 
