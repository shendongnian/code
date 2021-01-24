        public class AccountController : Controller
            {
                private readonly UserManager<AppUser> _userManager;
                private readonly SignInManager<AppUser> _signInManager;
                private readonly RoleManager<IdentityRole<string>> _roleManager;
        
                public AccountController(
                    UserManager<AppUser> userManager,
                    SignInManager<AppUser> signInManager,
                    RoleManager<IdentityRole<string>> roleManager)
                {
                    _userManager = userManager;
                    _signInManager = signInManager;
                    _roleManager = roleManager;
                }
        
                public IActionResult Register()
                {
                    return View();
                }
        
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Register(RegisterViewModel model)
                {
                    if(ModelState.IsValid)
                    {
                        AppUser user = new AppUser
                        {
                            FullName = model.FullName,
                            Email = model.Email,
                            UserName = model.Email
                        };
                        var createResult = await _userManager.CreateAsync(user, model.Password);
                        if(createResult.Succeeded)
                        {
                            await _userManager.AddClaimAsync(user, new Claim("sys:FullName", model.FullName));
                            if(!await _roleManager.RoleExistsAsync("User"))
                            {
                                await _roleManager.CreateAsync(new IdentityRole("User"));
                            }
    if(!await _roleManager.RoleExistsAsync("Dev"))
                            {
                                await _roleManager.CreateAsync(new IdentityRole("Dev"));
                            }
                            await _userManager.AddToRoleAsync(user, "User");
                            await _userManager.AddToRoleAsync(user, "Dev");
                            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            string url = Url.Action("ConfirmEmail", "Account", new
                            {
                                email = model.Email,
                                token
                            }, Request.Scheme);
                            System.IO.File.WriteAllText("ConfirmEmail.txt", url);
                            return RedirectToAction(nameof(Confirmation), new
                            {
                                confirmation = ConfirmationStatus.EmailConfirmation
                            });
                        }
                        foreach(var error in createResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
        
                    return View(model);
                }
