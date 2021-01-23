    public class Handler : IHttpHandler, System.Web.SessionState.IRequiresSessionState 
    {   
      public void ProcessRequest(HttpContext context)  
      {      
        context.Session["StackOverflow"] = "overflowing";      
        context.Response.Redirect("~/AnotherPage.aspx");      
      }
    
    }
