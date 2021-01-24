    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    
    public class Middle
    {
      private readonly RequestDelegate _next;
    
      public Middle(RequestDelegate next)
      {
        _next = next;
      }
    
      public async Task Invoke(HttpContext context)
      {
        string req_path = context.Request.Path.Value;
        string host = context.Request.Host.Value;
        
        if (host.StartsWith("photos.")) {
          context.Response.Clear();
          context.Response.StatusCode = 200;
          context.Response.ContentType = "<Image Type>";
          await context.Response.SendFileAsync(<file path>);
          return;
        }
        else {
          await _next.Invoke(context);
        }
      }
    }
