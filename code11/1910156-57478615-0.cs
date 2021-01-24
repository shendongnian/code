c#
//ConfigureServices method
 _ = services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OAuthDefaults.DisplayName;
              
            }).AddOAuth(OAuthDefaults.DisplayName, options =>
              {
                  //Get the configuration from appsettings.json
                  options.AuthorizationEndpoint = Configuration["oauth:auth_uri"];
                  options.TokenEndpoint = Configuration["oauth:token_uri"];
                  options.ClientId = Configuration["oauth:client_id"];
                  options.ClientSecret = Configuration["oauth:client_secret"];
                  var callback = Configuration["oauth:callback_path"].ToString();
                  options.CallbackPath = new PathString(callback);
                options.ClaimsIssuer = "https://YOUR_SERVER/adfs";
                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = OnCreatingTicket,
                };
              }).AddJwtBearer("Bearer",configureOptions=>
              {
                  configureOptions.Authority = "https://YOUR_SERVER/adfs";
                  configureOptions.Audience = "microsoft:identityserver:CLIENT_ID";
                  configureOptions.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = "http://YOUR_SERVER/adfs/services/trust",
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidAudience = "AUDIENCE",
                      ValidateLifetime = true,
                  };
                
              }).AddCookie();
 services.AddAuthorization(options =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                    JwtBearerDefaults.AuthenticationScheme,
                    "Bearer");
                defaultAuthorizationPolicyBuilder =
                    defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
                options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
              
            });
Now in your controller which calls from the web client the authorize is like this:
c#
  [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class WebController : Controller
    {
      //YOUR CODE
    }
if it is a web api controller the authorize is like this:
c#
 [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class WebApiController : ControllerBase
    {
      //Your code here
    }
This article is helpful too: https://medium.com/@gabriel.faraday.barros/adfs-angular-asp-net-core-api-5fc61ae89fb3
