public class Download : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        context.Response.WriteFile( context.Server.MapPath( context.Request.Params["file"] ) );
    }
 
    public bool IsReusable { get { return false; }
    }
}
