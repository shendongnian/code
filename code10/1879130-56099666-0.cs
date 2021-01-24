    var result = await graphClient.Me.Onenote.Pages.Request().GetAsync();
    foreach (var page in result)
    {
   
         //download Page content
         var message = new HttpRequestMessage(HttpMethod.Get, page.ContentUrl);
         await graphClient.AuthenticationProvider.AuthenticateRequestAsync(message);
         var response = await graphClient.HttpProvider.SendAsync(message);
         var content = await response.Content.ReadAsStringAsync();  //get content as HTML 
         
    }
