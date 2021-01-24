c#
  internal class MembershipRequirement : AuthorizationHandler<MembershipRequirement>, IAuthorizationRequirement
  {
    public MembershipRequirement(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public IConfiguration Configuration { get; }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MembershipRequirement requirement)
    {
      var authFilterCtx = (Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)context.Resource;
      string idToken = authFilterCtx.HttpContext.Request.Headers["x-id-token"];
      string membershipId = authFilterCtx.HttpContext.Request.Headers["x-selected-membership-id"];
      if (idToken != null && membershipId != null)
      {
        var identity = ValidateIdToken(idToken).Result;
        if (identity != null)
        {
          var subscriptions = identity.Claims.ToList().FindAll(s => s.Type == "https://example.com/subs").ToList();
          var assignments = subscriptions.Select(s => JsonSerializer.Deserialize<Subscription>(s.Value)).ToList();
          var membership = assignments.Find(a => a.id == membershipId);
          if (membership != null)
          {
            // assign the id token claims to user identity
            context.User.AddIdentity(new ClaimsIdentity(identity.Claims));
            context.Succeed(requirement);
          }
          else { context.Fail(); }
        }
        else
        {
          context.Fail();
        }
      }
      return Task.FromResult<object>(null);
    }
    private async Task<ClaimsPrincipal> ValidateIdToken(string token)
    {
      try
      {
        IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"https://{Configuration["Auth:Domain"]}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
        OpenIdConnectConfiguration openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
        TokenValidationParameters validationParameters =
                      new TokenValidationParameters
                      {
                        IssuerSigningKeys = openIdConfig.SigningKeys,
                        ValidateIssuer = false,
                        ValidateAudience = false
                      };
        var validator = new JwtSecurityTokenHandler();
        SecurityToken validatedToken;
        var identity = validator.ValidateToken(token, validationParameters, out validatedToken);
        return identity;
      }
      catch (Exception e)
      {
        Console.Writeline($"Error occurred while validating token: {e.Message}");
        return null;
      }
    }
  }
  internal class Subscription
  {
    public string name { get; set; }
    public string id { get; set; }
  }
Then in the `public void ConfigureServices(IServiceCollection services)` method added a policy to check for membership in the `id_token`
c#
      services.AddAuthorization(options =>
      {
        options.AddPolicy("RequiredCompanyMembership", policy => policy.Requirements.Add(new MembershipRequirement(Configuration)));
      });
For us, this policy is globally applied for all Authorized endpoints.
