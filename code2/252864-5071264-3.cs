    namespace skmHttpHandlers
    {
       public class JavascriptHandler : IHttpHandler
       {
          public void ProcessRequest(HttpContext context)
          {
             context.Response.Clear();
             context.Response.Cache.SetCacheability(HttpCacheability.NoCache)
             using (var scriptStream = File.Open(Server.MapPath(context.Request.RawUrl), FileMode.Open))
               scriptStream.CopyTo(context.Response.OutputStream);
             context.Response.End();
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
