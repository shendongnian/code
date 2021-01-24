    // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
    static readonly HttpClient client = new HttpClient();
     
    static async Task Main()
    {
      // Call asynchronous network methods in a try/catch block to handle exceptions
      try	
      {
         HttpResponseMessage response = await client.PostAsync("https://s16events.azure-automation.net/webhooks?token=sdnfgknsdkfglkshnklsdfhgoihohsndfgndfgknkkdfg", new StringContent(requestBody));
         response.EnsureSuccessStatusCode();
         string responseBody = await response.Content.ReadAsStringAsync();
    
         Console.WriteLine(responseBody);
      }  
      catch(HttpRequestException e)
      {
         Console.WriteLine("\nException Caught!");	
         Console.WriteLine("Message :{0} ",e.Message);
      }
    }
