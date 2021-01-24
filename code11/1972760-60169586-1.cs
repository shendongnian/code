public void LoadUserAuthInfo(AuthUserSession userSession, IAuthTokens tokens, Dictionary<string, string> authInfo, string domainName= someDefaultIfNoneProvided)
{
  if (userSession == null)
        return;
  string lookup = userSession.Id;
  List<string> domains = new List<string>() { "domain1", "domain2" };
  bool userFound = false;
  foreach (string domain in domains)  
  {
    using (var pc = new PrincipalContext(ContextType.Domain, domainName))
    {
       var user = UserPrincipal.FindByIdentity(pc, userSession.UserAuthName);
     
       // ---> Add Check here to prevent NRE
       if (user != null) {
           SingleSignOnResponse ssoB = new SingleSignOnResponse();
           ssoB.Username = user.Sid.Translate(typeof(NTAccount)).ToString();
           ssoB.Timestamp = DateTime.Now;
           SSOCache.Instance.TryAdd(lookup, ssoB);
           userFound = true;
           break; // No longer need to continue checking other domains.
       }
       else 
       {
           // Handle case when user does not exist.
       } 
    }
  }
  // Check if userFound = false. If so, do something with that exception.
}
