cs
services.AddIdentityServer()
                
                .AddInMemoryIdentityResources(GetIdentityResources())
//where
public static List<IdentityResource> GetIdentityResources()
{
  // Claims automatically included in OpenId scope
  var openIdScope = new IdentityResources.OpenId();
  openIdScope.UserClaims.Add(JwtClaimTypes.Locale);
  // Available scopes
  return new List<IdentityResource>
  {
    openIdScope,
    new IdentityResources.Profile(),
    new IdentityResources.Email(),
    new IdentityResource(Constants.RolesScopeType, Constants.RolesScopeType,
      new List<string> {JwtClaimTypes.Role, Constants.TenantIdClaimType})
      {
        //when false (default), the user can deselect the scope on consent screen
        Required = true 
      }
  };
}
