    using Microsoft.AspNetCore.Authentication;
     using Microsoft.AspNetCore.Authentication.OpenIdConnect;
     using Microsoft.AspNetCore.Authentication.Cookies;
     using Microsoft.IdentityModel.Tokens;
    public class LoginModel : PageModel
    {
        public async Task OnGet(string redirectUri)
        {
            await HttpContext.ChallengeAsync("oidc", new 
                AuthenticationProperties { RedirectUri = redirectUri } );
        }  
    }
