 csharp
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if(!_isUserLoggedIn)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
        else
        {
            var tokenResponse = await _authService.GetCurrentAuthTokenAsync();
            if (tokenResponse.HasError)
            {
                var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymousUser);
            }
            var claimsResponse = await _authService.GetCurrentUserClaimsAsync();
            if(claimsResponse.HasError)
            {
                var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymousUser);
            }
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenResponse.Result);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claimsResponse.Result, "apiAuth")));
        }
    }
