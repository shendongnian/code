[HttpPost]
[AllowAnonymous]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
{
    ViewData["ReturnUrl"] = returnUrl;
    if (model.Email.IndexOf('@') > -1)
    {
        //Validate email format
        string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                               @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(emailRegex);
        if (!re.IsMatch(model.Email))
        {
            ModelState.AddModelError("Email", "Email is not valid");
        }
    }
    else
    {
        //validate Username format
        string emailRegex = @"^[a-zA-Z0-9]*$";
        Regex re = new Regex(emailRegex);
        if (!re.IsMatch(model.Username))
        {
            ModelState.AddModelError("Username", "Username is not valid");
        }
    }
    if (ModelState.IsValid)
    {
        var userName = model.Email;
        if (userName.IndexOf('@') > -1)
        {
            var user =  await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
          
        }
        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
	}
}
public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username{ get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
