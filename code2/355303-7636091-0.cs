    <% @ webhandler language="C#" class="MyClass" %>
    
    using System;
    using System.Web;
    using System.Web.SessionState;
    
    public class MyClass: IHttpHandler, IReadOnlySessionState
    {
       public bool IsReusable { get { return true; } }
       
       public void ProcessRequest(HttpContext ctx)
       {
           ctx.Response.Write(ctx.Session["ID"]);
       }
    }
