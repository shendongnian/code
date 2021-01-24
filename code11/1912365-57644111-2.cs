[ServiceContract]
public interface IYourWebServiceNAme
{
    [OperationContract]
    String SayHello(String Name);
}
public class YourWebServiceImplement : IYourWebServiceNAme
{
    public YourWebServiceImplement ()
    {
    }
    private static string UserName { get; set; }
    private static string Password { get; set; }
    public static void Authenticate(string username, string password)
    {
       UserName = username;
       Password = password;
    }
    public String SayHello(String Name)
    {
      if(UserName=="mojtaba" && Password=="moradi")
      {
         return String.Format("Hello {0}, {1} , {2}",Name,UserName,Password);
      }
      else
      {
        return String.Format("Invalid User");   
      }
    }
}
write middle ware for get authorization header
 public class  SoapAuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        public  SoapAuthorizationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            
                string authHeader = context.Request.Headers["Authorization"];
                if (authHeader != null && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
                {
                    string token = authHeader.Substring("Basic ".Length).Trim();
                    var credentialstring = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var credentials = credentialstring.Split(':');
                    string username = credentials[0];
                    string password = credentials[1];
                    YourWebServiceImplement.Authenticate(username, password);
                }
                else
                {
                    YourWebServiceImplement.Authenticate(string.Empty, string.Empty);
                    context.Response.StatusCode = 401;
                    context.Response.Headers["WWW-Authenticate"] = "Basic";
                }
            
            await next(context);
        }
    }
then use this middle ware on startup.cs 
public void ConfigureServices(IServiceCollection services)
{
     //soap service
     services.TryAddSingleton<IYourWebServiceNAme, YourWebServiceImplement >();
}
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
 app.UseSoapEndpoint<IYourWebServiceName>("/yourservicename.asmx", new BasicHttpBinding(), SoapSerializer.XmlSerializer);
 app.UseWhen(x => (x.Request.Path.StartsWithSegments("/yourservicename.asmx", StringComparison.OrdinalIgnoreCase)),
            builder =>
            {
                builder.UseMiddleware<SoapAuthorizationMiddleware>();
            });
}
client code after added web service reference (webservicereference1)
  webservicereference1.IYourWebServiceNAmerm = new 
  webservicereference1.IYourWebServiceNAme();
            rm.Credentials = new System.Net.NetworkCredential("mojtaba", "moradi");
   var res= rm.SayHello("mojtabamoradi.net@outlook.com");
