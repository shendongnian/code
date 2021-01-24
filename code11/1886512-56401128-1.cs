    public async Task GetToken()
    {
         Dto dto = new Dto
         {
              //start assigning stuff to it here
              Grant_Type = "password",
              Username = "admin@encompass:BE11200822",
              //and so forth
         };
        using (HttpClient client = new HttpClient())
        {
              client.BaseAddress = new Uri("https://api.elliemae.com/");
              HttpRequestMessage request = new HttpRequestMessage
                  (HttpMethod.Post, "oauth2/v1/token")
                  {
                       Content = new StringContent(new JavaScriptSerializer().Serialize(dto), Encoding.UTF8, "application/json")
                  };
              request.Headers.Add("API_KEY", TestVariables.apiKey);
              HttpResponseMessage response = await client.SendAsync(request);
              //for now, see what response gets you and adjust your code to return the object you need 
        }
    }
