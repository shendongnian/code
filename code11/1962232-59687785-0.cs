    Notifications = new OpenIdConnectAuthenticationNotifications
    {
        SecurityTokenValidated = notification =>
        {
            var identity = notification.AuthenticationTicket.Identity;
            identity.AddClaim(claim: new Claim(type: "auth_token", value: 
               notification.ProtocolMessage.AccessToken));
            return Task.CompletedTask;
        }
    }
