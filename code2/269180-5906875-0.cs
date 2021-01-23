    void WSFederationAuthenticationModule_RedirectingToIdentityProvider(object sender, RedirectingToIdentityProviderEventArgs e)
    {
        string whr = HttpContext.Current.Request.QueryString["whr"]; 
        if (!string.IsNullOrEmpty(whr))
        {
            //add your logic to determine the STS
    		e.SignInRequestMessage.HomeRealm = @"http://path-to-STS";
        }
    }
