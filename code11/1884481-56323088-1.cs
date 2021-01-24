       [AllowAnonymous]
    public class RegisterModel : PageModel
    {
          private readonly IEmailSender _emailSender;
        public RegisterModel(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
         public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                               {
                                    UserName = Input.Email,
                                    Email = Input.Email,
                                    DateCreated = DateTime.Now
                                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    returnUrl = Url.Action("ConfirmEmail", "Home");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _userManager.AddToRoleAsync(user,"ROleName");
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);
 
