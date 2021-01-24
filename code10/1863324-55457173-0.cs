            var identityPricipal = await _principalFactory.CreateAsync(user);
            var identityUser = new IdentityServerUser(user.Id.ToString())
            {
                AdditionalClaims = identityPricipal.Claims.ToArray(),
                DisplayName = user.UserName,
                AuthenticationTime = DateTime.UtcNow,
                IdentityProvider = IdentityServerConstants.LocalIdentityProvider
            };
            var request = new TokenCreationRequest();
            request.Subject = identityUser.CreatePrincipal();
            request.IncludeAllIdentityClaims = true;
            request.ValidatedRequest = new ValidatedRequest();
            request.ValidatedRequest.Subject = request.Subject;
            request.ValidatedRequest.SetClient(Config.Clients().First());
            request.Resources = new Resources(Config.IdentityResources(), new List<ApiResource>());
            request.ValidatedRequest.Options = _options;
            request.ValidatedRequest.ClientClaims = identityUser.AdditionalClaims;
            var token = await _tokenService.CreateAccessTokenAsync(request);
            token.Issuer = "...";
            return await _tokenService.CreateSecurityTokenAsync(token);
