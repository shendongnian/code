public void LoadUserAuthInfo(AuthUserSession userSession, IAuthTokens tokens, Dictionary<string, string> authInfo, string domainName= someDefaultIfNoneProvided)
{
  if (userSession == null)
        return;
  string lookup = userSession.Id;
  using (var pc = new PrincipalContext(ContextType.Domain, domainName))
  {
     var user = UserPrincipal.FindByIdentity(pc, userSession.UserAuthName);
     
     // ---> Add Check here to prevent NRE
     if (user != null) {
         SingleSignOnResponse ssoB = new SingleSignOnResponse();
         ssoB.Username = user.Sid.Translate(typeof(NTAccount)).ToString();
         ssoB.Timestamp = DateTime.Now;
         SSOCache.Instance.TryAdd(lookup, ssoB);
     }
     else 
     {
         // Handle case when user does not exist.
     }
  }
}
