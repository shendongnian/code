    .AddMicrosoftAccount("Microsoft", "Microsoft", o =>
    {
        o.SignInScheme = IdentityConstants.ExternalScheme;
        o.ClientId = _externalKeysOptions.MicrosoftClientId;
        o.ClientSecret = _externalKeysOptions.MicrosoftClientSecret;
        o.CallbackPath = new PathString("/signin-microsoft");
        new[]
        {
            "offline_access",
            "Calendars.Read.Shared",
            "Calendars.ReadWrite",
            "Tasks.Readwrite",
            "openid"
        }.ForEach(scope => o.Scope.Add(scope));
        o.SaveTokens = true;
        o.Events = new OAuthEvents
        {
            OnRedirectToAuthorizationEndpoint = context =>
            {
                var uriBuilder = new UriBuilder(context.RedirectUri);
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["prompt"] = "select_account";
                uriBuilder.Query = query.ToString();
                var newRedirectUri = uriBuilder.ToString();
                context.Response.Redirect(newRedirectUri);
                return Task.CompletedTask;
            }
        };
    })
