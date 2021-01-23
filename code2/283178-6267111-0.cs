    protected void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender, SessionSecurityTokenReceivedEventArgs e)
    {
        var sessionToken = e.SessionToken;
        SymmetricSecurityKey symmetricSecurityKey = null;
        if (sessionToken.SecurityKeys != null)
            symmetricSecurityKey = sessionToken.SecurityKeys.OfType<SymmetricSecurityKey>().FirstOrDefault();
        Condition.Requires(symmetricSecurityKey, "symmetricSecurityKey").IsNotNull();
        if (sessionToken.ValidTo > DateTime.UtcNow)
        {
            var slidingExpiration = sessionToken.ValidTo - sessionToken.ValidFrom;
           
            e.SessionToken = new SessionSecurityToken(
                        sessionToken.ClaimsPrincipal,
                        sessionToken.ContextId,
                        sessionToken.Context,
                        sessionToken.EndpointId,
                        slidingExpiration,
                        symmetricSecurityKey);
            e.ReissueCookie = true;
        }
        else
        {
            var sessionAuthenticationModule = (SessionAuthenticationModule) sender;
 
            sessionAuthenticationModule.DeleteSessionTokenCookie();
 
            e.Cancel = true;
        }
    }
