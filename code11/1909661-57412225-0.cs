      public class AuthenticationMiddleware
        {
            private readonly RequestDelegate _next;
            //IConfiguration _ic;
            public AuthenticationMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
                //string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
                string AuthKey = ConfigurationManager.AppSetting["AuthKey"];
                string AuthPass = ConfigurationManager.AppSetting["AuthPass"];
                
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("Basic"))
                {
                    try
                    {
                        //Extract credentials
                        string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                        Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                        string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
                        int seperatorIndex = usernamePassword.IndexOf(':');
                        var username = usernamePassword.Substring(0, seperatorIndex);
                        var password = usernamePassword.Substring(seperatorIndex + 1);
                     
                        //string username1 = Encryption.Encrypt("test", username);
                        //string password1 = Encryption.Encrypt("test", password);
                        if (username == AuthKey && password == AuthPass)
                        {
                            await _next.Invoke(context);
                        }
                        else
                        {
                            context.Response.StatusCode = 401; //Unauthorized
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 401; //Unauthorized
                        return;
                    }
                }
                else
                {
                    context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"ABCProject\"";
                    // no authorization header
                    context.Response.StatusCode = 401; //Unauthorized
                    return;
                }
            }
        }
