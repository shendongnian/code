    var baseAddress = new Uri('http://localhost');
    
    HttpRequestMessage requestMessage = new HttpRequestMessage { Method = method };
    requestMessage.Headers.Add("custom1", "c1");
    requestMessage.Headers.Add("custom2", "c2");
    // requestMessage.Headers.Add("Cookie", "c3"); wrong way to do it
    
    var cookieContainer = new CookieContainer();
    using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
    {
       using(HttpClient client = new HttpClient(handler) { BaseAddress = baseAddress })
       {
           cookieContainer.Add(baseAddress, new Cookie("CookieName", "cookie_value"));
           using (var response = await client.SendAsync(requestMessage, cancellationToken))
           using (var responseStream = await response.Content.ReadAsStreamAsync())
           {
                  // do your stuff
           }
       }
    }
