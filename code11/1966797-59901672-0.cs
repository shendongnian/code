         public class HostAuthenticationModel : PageModel
         {
		     public async Task<IActionResult> OnGet()
             {
                 if (User.Identity.IsAuthenticated)
                 {
                    var token = await HttpContext.GetTokenAsync("access_token");
                    AccessToken = token;
                
                 }
            return Page();
         }
         public string AccessToken { get; set; }
         }
