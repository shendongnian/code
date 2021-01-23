    <%@ WebHandler Language="C#" Class="Handler" %>
    public class NetworkImageHandler : System.Web.IHttpHandler
    {
      public void HandlerRequest(HttpContext context)
      {
          Response.ContentType = "image/jpg";
          Response.WriteFile("\\my-network-computer\my-folder\my-file.jpg", true);
      }
      public bool IsReusable { get { return false; } }
    }
