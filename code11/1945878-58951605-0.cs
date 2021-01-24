    public class Test{
     private static HttpClient _httpClient;
     
     SomeFunction(){
     using (var client = new HttpClient(
           HttpClientFactory.CreatePipeline(
           new HttpClientHandler
               {
                  CookieContainer = new CookieContainer(),
                  UseCookies = true
                },
           new DelegatingHandler[] { new CustomHandler() })))
        {
             //do something with `client`
        }  
    
     }
    }
