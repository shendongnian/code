        var claims = new List<Claim>
        {
            new Claim(WSIdentityConstants.ClaimTypes.Name, User.Identity.Name),
            new Claim(ClaimTypes.AuthenticationMethod, FormsAuthenticationHelper.GetAuthenticationMethod(User.Identity))
        };
            var identity = new ClaimsIdentity(claims, STS.TokenServiceIssueTypes.Native);
            var principal = ClaimsPrincipal.CreateFromIdentity(identity);
            FederatedPassiveSecurityTokenServiceOperations.ProcessRequest(
                Request,
                principal,
                StarterTokenServiceConfiguration.Current.CreateSecurityTokenService(),
                Response);
