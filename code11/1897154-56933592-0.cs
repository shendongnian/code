    public class CorsOverride
    {
      private readonly RequestDelegate _next;
    
      public CorsOverride(RequestDelegate next)
      {
        _next = next;
      }
    
      public async Task Invoke(HttpContext httpContext)
      {
        const string allowOriginHeaderName = "Access-Control-Allow-Origin";
        if (httpContext.Response.Headers.ContainsKey(allowOriginHeaderName))
        {
          httpContext.Response.Headers.Remove(allowOriginHeaderName);
        }
    
        httpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
        httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "x-requested-with");
    
        if (httpContext.Request.Headers["Access-Control-Request-Method"].Count > 0)
        {
          foreach (var header in httpContext.Request.Headers["Access-Control-Request-Method"])
          {
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", header);
          }
        }
        else
        {
          httpContext.Response.Headers.Add("Access-Control-Allow-Methods", httpContext.Request.Method);
        }
    
        foreach (var origin in httpContext.Request.Headers.Where(h => h.Key == "Origin"))
        {
          httpContext.Response.Headers.Add(allowOriginHeaderName, origin.Value);
        }
    
        if (httpContext.Request.Method == "OPTIONS")
        {
          httpContext.Response.StatusCode = 200;
          await httpContext.Response.WriteAsync("");
        }
        else
        {
          await _next.Invoke(httpContext);
        }
      }
    }
