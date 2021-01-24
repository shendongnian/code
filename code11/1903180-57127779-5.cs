    public static async Task<HttpResponseMessage> Run(HttpRequest req, ILogger log)
    {
        dynamic data = await req.Content.ReadAsAsync<object>();
    
        // ..
        
        var payload = JsonConvert.SerializeObject(new
        {
            a = matchedList,
            b = unmatchedList
        });
        
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        
        return new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
    } 
