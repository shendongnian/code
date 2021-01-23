    void SessionAuthenticationModule_SessionSecurityTokenReceived(object sender,
                    
    System.IdentityModel.Services.SessionSecurityTokenReceivedEventArgs e)
    { 
        DateTime now = DateTime.UtcNow;
        SessionSecurityToken sst = e.SessionToken;
        DateTime validFrom = sst.ValidFrom;
        DateTime validTo = sst.ValidTo; 
        if ((now < validTo) && (now > validFrom.AddMinutes( (validTo.Minute - validFrom.Minute) / 2)) ) 
        { 
            SessionAuthenticationModule sam = sender as SessionAuthenticationModule;
            e.SessionToken = sam.CreateSessionSecurityToken(sst.ClaimsPrincipal,
                                                            sst.Context,
                                                            now,
                                                            now.AddMinutes(2),
                                                            sst.IsPersistent); 
                                                            e.ReissueCookie = true; 
        }
    }
