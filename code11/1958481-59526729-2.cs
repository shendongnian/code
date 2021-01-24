lang-powershell
Install-Package AspNet.Security.OAuth.Slack -Version 3.0.0
and edit your `Startup.cs` like so: 
csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddAuthentication(options => { /* your options verbatim */ })
            .AddSlack(options =>
            {
                options.ClientId = "xxx";
                options.ClientSecret = "xxx";
            });
}
I see you opted to map your login/logout routes directly in the Startup class, which might actually be the issue - calls to `.Map()` branch the request pipeline and therefore you don't hit the same middleware chain you set up earlier), so I went with a separate controller (as per [sample app][2]):
csharp
public class AuthenticationController : Controller
    {
        [HttpGet("~/signin")]
        public async Task<IActionResult> SignIn()
        {
            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Slack");
        }
        [HttpGet("~/signout"), HttpPost("~/signout")]
        public IActionResult SignOut()
        {
            // Instruct the cookies middleware to delete the local cookie created
            // when the user agent is redirected from the external identity provider
            // after a successful authentication flow (e.g Google or Facebook).
            return SignOut(new AuthenticationProperties { RedirectUri = "/" },
                CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
Looking at your snippet I however suspect you already installed this nuget package and tried to use it. Which leads me to recommend a few things to check out:
1. double check your redirect URL in slack app configuration, 
1. check whether your `identity.basic` scope is actually enabled for your app
1. try handling login actions in separate controller rather than startup class
1. ensure your application runs with SSL: `**Project properties** -> **Debug** tab -> **Enable SSL** checkbox` (if IIS express hosted, otherwise you might need to do a [bit of extra work][3])
1. check out [the sample project][2], it might give you an idea how your setup is different
**UPD**: so after some back and forth I was able to get a better view of your issue. I do believe what you are observing is separate to logging in with slack and rather has to do with their app install flow. As you already pointed out, the difference between the "add to slack" flow and user login is - the `state` parameter is not part of your source URL and therefore is not returned back to you across requests. This is a huge deal for the oAuth handler as it relies on `state` to validate request integrity and simply fails if state is empty. There's been a [discussion on github][4] but the outcome I believe was - you're going to have to skip the validation part yourself.
So I inherited from `SlackAuthenticationHandler` that comes with the nuget package and removed the bits of code that gave me the issue:
csharp
    public class SlackNoStateAuthenticationHandler : SlackAuthenticationHandler {
        public SlackNoStateAuthenticationHandler([NotNull] IOptionsMonitor<SlackAuthenticationOptions> options,
            [NotNull] ILoggerFactory logger,
            [NotNull] UrlEncoder encoder,
            [NotNull] ISystemClock clock) : base(options, logger, encoder, clock) { }
        public void GenerateCorrelationIdPublic(AuthenticationProperties properties)
        {
            GenerateCorrelationId(properties);
        }
        protected override async Task<HandleRequestResult> HandleRemoteAuthenticateAsync()
        {
            var query = Request.Query;
            var state = query["state"];
            var properties = Options.StateDataFormat.Unprotect(state);
            var error = query["error"];
            if (!StringValues.IsNullOrEmpty(error))
            {
                // Note: access_denied errors are special protocol errors indicating the user didn't
                // approve the authorization demand requested by the remote authorization server.
                // Since it's a frequent scenario (that is not caused by incorrect configuration),
                // denied errors are handled differently using HandleAccessDeniedErrorAsync().
                // Visit https://tools.ietf.org/html/rfc6749#section-4.1.2.1 for more information.
                if (StringValues.Equals(error, "access_denied"))
                {
                    return await HandleAccessDeniedErrorAsync(properties);
                }
                var failureMessage = new StringBuilder();
                failureMessage.Append(error);
                var errorDescription = query["error_description"];
                if (!StringValues.IsNullOrEmpty(errorDescription))
                {
                    failureMessage.Append(";Description=").Append(errorDescription);
                }
                var errorUri = query["error_uri"];
                if (!StringValues.IsNullOrEmpty(errorUri))
                {
                    failureMessage.Append(";Uri=").Append(errorUri);
                }
                return HandleRequestResult.Fail(failureMessage.ToString(), properties);
            }
            var code = query["code"];
            if (StringValues.IsNullOrEmpty(code))
            {
                return HandleRequestResult.Fail("Code was not found.", properties);
            }
            var tokens = await ExchangeCodeAsync(new OAuthCodeExchangeContext(properties, code, BuildRedirectUri(Options.CallbackPath)));
            if (tokens.Error != null)
            {
                return HandleRequestResult.Fail(tokens.Error, properties);
            }
            if (string.IsNullOrEmpty(tokens.AccessToken))
            {
                return HandleRequestResult.Fail("Failed to retrieve access token.", properties);
            }
            var identity = new ClaimsIdentity(ClaimsIssuer);
            if (Options.SaveTokens)
            {
                var authTokens = new List<AuthenticationToken>();
                authTokens.Add(new AuthenticationToken { Name = "access_token", Value = tokens.AccessToken });
                if (!string.IsNullOrEmpty(tokens.RefreshToken))
                {
                    authTokens.Add(new AuthenticationToken { Name = "refresh_token", Value = tokens.RefreshToken });
                }
                if (!string.IsNullOrEmpty(tokens.TokenType))
                {
                    authTokens.Add(new AuthenticationToken { Name = "token_type", Value = tokens.TokenType });
                }
                if (!string.IsNullOrEmpty(tokens.ExpiresIn))
                {
                    int value;
                    if (int.TryParse(tokens.ExpiresIn, NumberStyles.Integer, CultureInfo.InvariantCulture, out value))
                    {
                        // https://www.w3.org/TR/xmlschema-2/#dateTime
                        // https://msdn.microsoft.com/en-us/library/az4se3k1(v=vs.110).aspx
                        var expiresAt = Clock.UtcNow + TimeSpan.FromSeconds(value);
                        authTokens.Add(new AuthenticationToken
                        {
                            Name = "expires_at",
                            Value = expiresAt.ToString("o", CultureInfo.InvariantCulture)
                        });
                    }
                }
                properties.StoreTokens(authTokens);
            }
            var ticket = await CreateTicketAsync(identity, properties, tokens);
            if (ticket != null)
            {
                return HandleRequestResult.Success(ticket);
            }
            else
            {
                return HandleRequestResult.Fail("Failed to retrieve user information from remote server.", properties);
            }
        }
    }
Most of this code is verbatim copy of the [relevant source][5], so you could always make more changes if need be;
 
Then we need to inject the sensible state parameter into your URL. Assuming you've got a controller and a view:
### HomeController
csharp
public class HomeController : Controller
    { 
        private readonly IAuthenticationHandlerProvider _handler;
        public HomeController(IAuthenticationHandlerProvider handler)
        {
            _handler = handler;
        }
        public async Task<IActionResult> Index()
        {
            var handler = await _handler.GetHandlerAsync(HttpContext, "Slack") as SlackNoStateAuthenticationHandler; // we'd get the configured instance
            var props = new AuthenticationProperties { RedirectUri = "/" }; // provide some sane defaults
            handler.GenerateCorrelationIdPublic(props); // generate xsrf token and add it into the properties object
            ViewBag.state = handler.Options.StateDataFormat.Protect(props); // and push it into your view.
            return View();
        }
}
### Startup.cs
csharp
.AddOAuth<SlackAuthenticationOptions, SlackNoStateAuthenticationHandler>(SlackAuthenticationDefaults.AuthenticationScheme, SlackAuthenticationDefaults.DisplayName, options =>
            {
                options.ClientId = "your_id";
                options.ClientSecret = "your_secret";
            });
### Index.cshtml
razor
<a href="https://slack.com/oauth/authorize?client_id=<your_id>&scope=identity.basic&state=@ViewBag.state"><img alt="Add to Slack" height="40" width="139" src="https://platform.slack-edge.com/img/add_to_slack.png" srcset="https://platform.slack-edge.com/img/add_to_slack.png 1x, https://platform.slack-edge.com/img/add_to_slack@2x.png 2x"></a>
this allowed me to successfully complete the request, although I'm not entirely sure if doing this will be considered best practice
  [1]: https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers
  [2]: https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers/tree/dev/samples/Mvc.Client
  [3]: https://stackoverflow.com/questions/46621788/how-to-use-https-ssl-with-kestrel-in-asp-net-core-2-x
  [4]: https://github.com/aspnet/AspNetCore/issues/1871
  [5]: https://github.com/aspnet/AspNetCore/blob/62351067ff4c1401556725b401478e648b66acdc/src/Security/Authentication/OAuth/src/OAuthHandler.cs#L45
