    public class MyFileHandler : IHttpHandler
    {
      public bool IsReusable
      {
        get { return true; }
      }
    
      public void ProcessRequest(HttpContext context)
      {
        string filePath = Path.Combine(@"d:\wwwroot\portal_daten", context.Request.QueryString["dateiname"]);
    
        context.Response.ContentType = "application/pdf";
        context.Response.WriteFile(filePath);
      }
    }
