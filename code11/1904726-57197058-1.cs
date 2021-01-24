    static public async Task<HttpResponseMessage> Validate(string baseUri, HttpContent content)
    {  
       return await client.PostAsync(baseUri,content);
    }
    
    public async Task<string> test()
    {
       var postJson = "{Login = \"user\", Password =  \"pwd\"}";
       var stringContent = new StringContent(postJson, UnicodeEncoding.UTF8, "application/json");
       var result = await Validate(Uri,stringContent);
       return await result.Content.ReadAsStringAsync();
    }
