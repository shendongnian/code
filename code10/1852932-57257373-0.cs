c#
    public class LoginByGrant : ICustomGrantValidator
    {
        private readonly ApplicationUserManager _userManager;
		public string GrantType => "loginBy";
		
        public LoginByGrant(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }     
        public async Task<CustomGrantValidationResult> ValidateAsync(ValidatedTokenRequest request)
        {
            var userId = Guid.Parse(request.Raw.Get("user_id"));
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return await Task.FromResult<CustomGrantValidationResult>(new CustomGrantValidationResult("user not exist"));
            
            var userClaims = await _userManager.GetClaimsAsync(user.Id);
            return
                await Task.FromResult<CustomGrantValidationResult>(new CustomGrantValidationResult(user.Id.ToString(), "custom", userClaims));
        }
    }
then add this custom grant in identity startup class
c#
    factory.CustomGrantValidators.Add(
                        new Registration<ICustomGrantValidator>(resolver => new LoginByGrant(ApplicaionUserManager)));
    		
		
and finally in your api
c#
      public async Task<IHttpActionResult> LoginBy(Guid userId)
       {
        var tokenClient = new TokenClient(Constants.TokenEndPoint, Constants.ClientId, Constants.Secret);
        var payload = new { user_id = userId.ToString() };
        var result = await tokenClient.RequestCustomGrantAsync("loginBy", "customScope", payload);
        if (result.IsError)
            return Ok(result.Json);
        return Ok(new { access_token = result.AccessToken, expires_in = result.ExpiresIn});
       }
this is for identityServer3 but for identityServer4 it is pretty similar
