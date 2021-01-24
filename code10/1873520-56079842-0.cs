    public class Global : HttpApplication
    {
       private static HttpRequest initialRequest;
    
       static Global()
       {
          initialRequest = HttpContext.Current.Request;       
       }
    
       void Application_Start(object sender, EventArgs e)
       {
          //access the initial request here
        
        }
