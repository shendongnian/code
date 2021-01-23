    namespace skmHttpHandlers
    {
       public class JavascriptHandler : IHttpHandler
       {
          public void ProcessRequest(HttpContext context)
          {
             //Write .js file here and turn of caching
          }
    
          public bool IsReusable
          {
             get
             {
                return false;
             }
          }
       }
    }
