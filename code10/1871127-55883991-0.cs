cs
.AddOAuth("lwa-oauth", "OauthLoginWithAmazon", options =>
{
    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    
    options.ClientId = "amzn1.application-oa2-client.zzzzzzzzzzzz";
    options.ClientSecret = "4c0630b4166c901519a730835ezzzzzzzzzzzzzzzz";
    options.SaveTokens = true;
    options.CallbackPath = "/signin-amazon";
    options.Scope.Clear();
    options.Scope.Add("profile");
    options.AuthorizationEndpoint = "https://www.amazon.com/ap/oa";
    options.TokenEndpoint = "https://api.amazon.com/auth/o2/token";
    options.UserInformationEndpoint = "https://api.amazon.com/user/profile";
    options.Events = new OAuthEvents
    {
         OnCreatingTicket = async context =>
         {
            var accessToken = context.AccessToken;
            HttpResponseMessage responseMessage = 
                 await context.Backchannel.SendAsync(
                        new HttpRequestMessage(HttpMethod.Get, options.UserInformationEndpoint)
            {
              Headers = 
              {
                    Authorization = new AuthenticationHeaderValue("Bearer", accessToken)
              }
            });
            responseMessage.EnsureSuccessStatusCode();
            string userInfoResponse = await responseMessage.Content.ReadAsStringAsync();
            var user = JObject.Parse(userInfoResponse);
            var claims = new[]
            {
              new Claim(JwtClaimTypes.Subject, user["user_id"].ToString()),
              new Claim(JwtClaimTypes.Email, user["email"].ToString()),
              new Claim(JwtClaimTypes.Name, user["name"].ToString())
            };
            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims));
            context.Success();
       }
   };
})
