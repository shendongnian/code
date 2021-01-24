services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
      .AddAzureAD(options => configuration.Bind(configSectionName, options));
  services.Configure<AzureADOptions>(options => configuration.Bind(configSectionName, options));
services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
options.Authority = options.Authority + "/v2.0/";
options.TokenValidationParameters.NameClaimType = "preferred_username";
 // Use the groups claim for populating roles
              options.TokenValidationParameters.RoleClaimType = "groups";
});
 services.AddMvc(options =>
      {
          var policy = new AuthorizationPolicyBuilder()
              .RequireAuthenticatedUser()
              .Build();
            options.Filters.Add(new AuthorizeFilter(policy));
            })
        .SetCompatibilityVersion(CompatibilityVersion.Latest);
2. Add the following code in the controller or method
if(User.Identity.IsAuthenticated){
   if (User.IsInRole("<group id>"))
            {
                 // do other action
            }
            else if (User?.FindFirst("_claim_names")?.Value != null)
            {
                /* call Graph API to check if the user is in the group
                     for example
                     GraphServiceClient client = await MicrosoftGraphClient.GetGraphServiceClient();
var memberOfGroups= await client.Me.TransitiveMemberOf.Request().GetAsync();
                    do
                    {
                        bool breakLoops = false;
                        foreach (var directoryObject in memberOfGroups.CurrentPage)
                        {
                            if (directoryObject is Group)
                            {
                                Group group = directoryObject as Group;
                                if (group.Id == "<group id>") {
                                    breakLoops = true;
                                    break;
                                }
                                
                            }
                        }
                        if (breakLoops)
                        {
                            break;
                        }
                        if (memberOfGroups.NextPageRequest != null)
                        {
                            memberOfGroups = await memberOfGroups.NextPageRequest.GetAsync();
                        }
                        else
                        {
                            memberOfGroups = null;
                        }
                    } while (memberOfGroups != null);
               */
            }
            else {
                // do not have enough permissions
            }
}
For more details, please refer to the [sample][1]
  [1]: https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/tree/master/5-WebApp-AuthZ/5-2-Groups
