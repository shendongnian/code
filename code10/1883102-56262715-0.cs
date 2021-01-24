    [HttpPost]
    [ActionName("donotcare")]
    public async Task<HttpResponseMessage> DoNotCare()
    {
        using(HttpClient client = new HttpClient())
        {
           client.BaseAddress = new Uri("http://localhost:3232/"); 
           var request = new HttpRequestMessage
             (HttpMethod.Post, "abc/xyz");  // or "mno/eee?key=asdad"
           HttpResponseMessage response = await client.SendAsync(request);
           return response;
        }
    }
