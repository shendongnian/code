c#
public async Task ValidateAsync(ExtensionGrantValidationContext context)
{
  var userId = context.Request.Raw[UserIdKey];
  ...
  var claims = new List<Claim>
  {
    new Claim(UserIdKey, userId)
  }
  context.Result = new GrantValidationResult(sub, GrantType, claims);
}
I then added the class to the Dependency Injection
c#
builder.AddExtensionGrantValidator<UserInfoGrant>();
I also have a class ProfileService that implements IProfileService which adds the claims to the token that is returned
c#
public virtual async Task GetProfileDataAsync(ProfileDataRequestContext context)
{
  var authenticationType = context.Subject.Identities.First().AuthenticationType;
  var isCustomAuthenticationType = authenticationType.Equals(CustomGrantName,
    StringComparison.OrdinalIgnoreCase);
  if (isCustomAuthenticationType)
  {
    var claimsToAdd = context.Subject.Identities.First().Claims;
    context.IssuedClaims = claimsToAdd.ToList();
  }
  else { ... }
This ProfileService was also added to DI
c#
builder.AddProfileService<Helpers.ProfileService<TUser>>();
I also added the custom grant type to the client that would be using it.
Finally, in the calling code for Website A, I request the token with this:
c#
var tokenResponse = await client.RequestTokenAsync(new TokenRequest {
                    Address = disco.TokenEndpoint,
                    ClientId = CLIENTID,
                    ClientSecret = CLIENTSECRET,
                    GrantType = "custom_grant_name",
                    Parameters = {
                        { "scope", PROTECTED_RESOURCE_NAME },
                        { "user_id", "26616" }
                      }
                    }).ConfigureAwait(false);
