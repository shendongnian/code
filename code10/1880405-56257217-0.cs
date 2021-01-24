cs
//configuration
services.AddOidcStateDataFormatterCache(Constants.MyExternalIdIdpName);
cs
//AccountController
[HttpGet]
public IActionResult Login(string returnUrl)
{
  string provider = Constants.MyExternalIdIdpName;
  string returnUrl2 = Url.Action("ExternalLoginCallback", new { returnUrl = returnUrl });
  // start challenge and roundtrip the return URL
  var props = new AuthenticationProperties
  {
    RedirectUri = returnUrl2,
    Items = { { "scheme", provider } }
  };
  return new ChallengeResult(provider, props);
}
and then
cs
[HttpGet]
public async Task<IActionResult> ExternalLoginCallback(string returnUrl)
{
  // read external identity from the temporary cookie
  var result = await HttpContext.AuthenticateAsync(IdentityServer4.IdentityServerConstants.ExternalCookieAuthenticationScheme);
  // retrieve claims of the external user
  var claims = result.Principal.Claims.ToList();
  var userIdClaim = claims.FirstOrDefault(x => x.Type == JwtClaimTypes.Subject);
  var user = <users>.FindByExternalProvider(provider, userIdClaim.Value);
  await _events.RaiseAsync(new UserLoginSuccessEvent(provider, userId, user.SubjectId, user.Username));
  await HttpContext.SignInAsync(user.SubjectId, user.Username, provider, props, additionalClaims.ToArray());
  // delete temporary cookie used during external authentication
  await HttpContext.SignOutAsync(IdentityServer4.IdentityServerConstants.ExternalCookieAuthenticationScheme);
  // validate return URL and redirect back to authorization endpoint or a local page
  if (_interaction.IsValidReturnUrl(returnUrl) || Url.IsLocalUrl(returnUrl))
  {
    return Redirect(returnUrl);
  }
  return Redirect("~/");
}
