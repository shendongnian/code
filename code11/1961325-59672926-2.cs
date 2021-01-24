using Microsoft.AspNetCore.Authentication;
    `public class LogoutModel : PageModel
     {
        public async Task<IActionResult> OnGetAsync()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }`
