 c#
public class LogoutModel : CustomPageModel
{
    private readonly SignInManager _signInManager;
    public LogoutModel(SignInManager signInManager) => _signInManager = signInManager;
    public string StatusMessage { get; set; }
    
    public async Task<IActionResult> OnGetAsync()
    {
        if (_signInManager.IsSignedIn(User))
        {
            await _signInManager.SignOutAsync();
            StatusMessage = "Successfully logged out!";
            return Page();
        }
        else {
            StatusMessage = "Already logged out!";
            return Page();
        }
        
    }
}
Logout.cshtml
@page
@model X.LogoutModel
@Model.StatusMessage
