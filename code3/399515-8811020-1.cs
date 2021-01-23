    public class BasicAuthenticationModule: IHttpModule
    {
      public void Init(HttpApplication application)
      {
        application.AuthenticateRequest += new EventHandler(Do_Authentication);
      }
      private void Do_Authentication(object sender, EventArgs e)
      {
        var request = HttpContext.Current.Request;
        string header = request.Headers["HTTP_AUTHORIZATION"];
        if(header != null && header.StartsWith("Basic "))
        {
          // Header is good, let's check username and password
          string username = DecodeFromHeader(header, "username");
          string password = DecodeFromHeader(header, password);
          if(Validate(username, password) 
          {
            // Create a custom IPrincipal object to carry the user's identity
            HttpContext.Current.User = new BasicPrincipal(username);
          }
          else
          {
            Protect();
          }
        }
        else
        {
          Protect();
        }
      }
      private void Protect()
      {
        response.StatusCode = 401;
        response.Headers.Add("WWW-Authenticate", "Basic realm=\"Test\"");
        response.Write("You must authenticate");
        response.End();
      }
      private void DecodeFromHeader()
      {
        // Figure this out based on spec
        // It's basically base 64 decode and split on the :
        throw new NotImplementedException();
      }
      private bool Validate(string username, string password)
      {
        return (username == "foo" && pasword == "bar");
      }
      public void Dispose() {}
      public class BasicPrincipal : IPrincipal
      {
        // Implement simple class to hold the user's identity
      }
    }
