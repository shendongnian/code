 c#
public class LogoutModel : CustomPageModel
{
    private readonly SignInManager _signInManager;
    public LogoutModel(SignInManager signInManager) => _signInManager = signInManager;
    public async Task<IActionResult> OnGetAsync()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("Page1"); // or set an string variable1 that is rendered in the razor page.
        }
        else {
            return RedirectToPage("Page2"); // or set an string variable2 that is rendered in the razor page.
        }
        
    }
}
