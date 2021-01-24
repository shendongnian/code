    public override async Task<TokenResponse> GetTokenAsync(HttpClient client, string address)
    {
        return await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = address,
            UserName = Username,
            Password = Password,
            GrantType = "password",
            ClientId = ClientId,
            ClientSecret = ClientSecret,
            Scope = "Api roles"
        });
    }
