    async Task<string> GetResponseString(SigupModel signup)
    {
      Sjson = JsonConvert.SerializeObject(signup);   
      var httpContent = new StringContent(Sjson);    
      using (HttpClient client = new HttpClient())
       {
         client.BaseAddress = new Uri("https://apiname.azurewebsites.net");
         var response =  await client.PostAsync("api/values", httpContent);    
         var responseContent =  await response.Content.ReadAsStringAsync();   
       }
     return responseContent;
    }
