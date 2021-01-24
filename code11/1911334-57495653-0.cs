 c#
new Client
{
    AllowedScopes = new List<string>
    {
        IdentityServerConstants.StandardScopes.OpenId,
        "custom"
    },
    // etc...
And then on the client configure `ResponseType = OpenIdConnectResponseType.IdTokenToken;`:
 c#
.AddOpenIdConnect(o =>
{
    o.Scope.Clear();
    o.Scope.Add("openid");
    o.Scope.Add("custom");
    o.ResponseType = OpenIdConnectResponseType.IdTokenToken;
    // etc...
