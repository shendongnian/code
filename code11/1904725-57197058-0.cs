    static public async Task<HttpResponseMessage> Validate(string baseUri, HttpContent content)
    {  
       return await client.PostAsync(baseUri,content);
    }
    
    public string test()
    {
       var postJson = "{Login = \"user\", Password =  \"pwd\"}";
       var stringContent = new StringContent(postJson, UnicodeEncoding.UTF8, "application/json");
       var result = Validate(Uri,stringContent).Result;
       var json=result.Content.ReadAsStringAsync().Result;
    }
