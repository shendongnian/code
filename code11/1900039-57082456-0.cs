    public class TokenAuthorizationRequirement: IAuthorizationRequirement {}
    
    services.AddMvc(config => {
       var policy = new AuthorizationPolicyBuilder()
          .AddAuthenticationSchemes(new[] {BasicAuthenticationDefaults.AuthenticationScheme })
          .AddRequirements(new BasicAuthorizationRequirement())
          .Build();
       config.Filters.Add(new AuthorizeFilter(policy));
    });
