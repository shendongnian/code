csharp
var slackState = Guid.NewGuid().ToString("N");
services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
            options.LoginPath = "/login";
            options.LogoutPath = "/logout";
        })
         .AddSlack(options =>
        {
            options.ClientId = Configuration["Slack:ClientId"];
            options.ClientSecret = Configuration["Slack:ClientSecret"];
            options.CallbackPath = $"{SlackAuthenticationDefaults.CallbackPath}?state={slackState}";
            options.ReturnUrlParameter = new PathString("/");
            options.Events = new OAuthEvents()
            {
                OnCreatingTicket = async context =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"{context.Options.UserInformationEndpoint}?token={context.AccessToken}");
                    var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();
                    var userObject = JObject.Parse(await response.Content.ReadAsStringAsync());
                    var user = userObject.SelectToken("user");
                    var userId = user.Value<string>("id");
                    if (!string.IsNullOrEmpty(userId))
                    {
                        context.Identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userId, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                    }
                    var fullName = user.Value<string>("name");
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        context.Identity.AddClaim(new Claim(ClaimTypes.Name, fullName, ClaimValueTypes.String, context.Options.ClaimsIssuer));
                    }
                }
            };
        });
My AuthenticationController now looks like:
csharp
public class AuthenticationController : Controller
{
    private readonly ILogger<AuthenticationController> _logger;
    private readonly AppSettings _appSettings;
    public AuthenticationController(ILogger<AuthenticationController> logger, IOptionsMonitor<AppSettings> appSettings)
    {
        _logger = logger;
        _appSettings = appSettings.CurrentValue;
    }
    [HttpGet("~/login")]
    public IActionResult SignIn()
    {
        return Challenge(new AuthenticationProperties { RedirectUri = "/" }, "Slack");
    }
    [HttpGet("~/signin-slack")]
    public async Task<IActionResult> SignInSlack()
    {
        var clientId = _appSettings.Slack.ClientId;
        var clientSecret = _appSettings.Slack.ClientSecret;
        var code = Request.Query["code"];
        SlackAuthRequest slackAuthRequest;
        string responseMessage;
        var requestUrl = $"https://slack.com/api/oauth.access?client_id={clientId}&client_secret={clientSecret}&code={code}";
        var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
        using (var client = new HttpClient())
        {
            var response = await client.SendAsync(request).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            slackAuthRequest = JsonConvert.DeserializeObject<SlackAuthRequest>(result);
        }
        if (slackAuthRequest != null)
        {
            _logger.LogInformation("New installation of StanLeeBot for {TeamName} in {Channel}", slackAuthRequest.TeamName, slackAuthRequest.IncomingWebhook.Channel);
            var webhookUrl = slackAuthRequest.IncomingWebhook.Url;
            var sbmClient = new SbmClient(webhookUrl);
            var message = new Message
            {
                Text = "Hi there from StanLeeBot!"
            };
            await sbmClient.SendAsync(message).ConfigureAwait(false);
            responseMessage = $"Congrats! StanLeeBot has been successfully added to {slackAuthRequest.TeamName} {slackAuthRequest.IncomingWebhook.Channel}";
            return RedirectToPage("/Index", new { message = responseMessage });
        }
        _logger.LogError("Something went wrong making a request to {RequestUrl}", requestUrl);
        responseMessage = "Error: Something went wrong and we were unable to add StanLeeBot to your Slack.";
        return RedirectToPage("/Index", new { message = responseMessage });
    }
    [HttpGet("~/logout"), HttpPost("~/logout")]
    public IActionResult SignOut()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/" },
            CookieAuthenticationDefaults.AuthenticationScheme);
    }
}
SmbClient is a Nuget package called SlackBotMessages that is used to send messages. So after the user authenticates, a message is automatically sent to that channel welcoming the user. 
Thank you all very much for your help! Let me know what you think or if you see any gotchas.
