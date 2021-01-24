 config.SignIn.RequireConfirmedEmail = true;
  
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("DefaultConnection")));
    services.AddDefaultIdentity<IdentityUser>(config =>
    {
        config.SignIn.RequireConfirmedEmail = true;
    })
        .AddDefaultUI(UIFramework.Bootstrap4)
        .AddEntityFrameworkStores<ApplicationDbContext>();
    // requires
    // using Microsoft.AspNetCore.Identity.UI.Services;
    // using WebPWrecover.Services;
    services.AddTransient<IEmailSender, EmailSender>();
    services.Configure<AuthMessageSenderOptions>(Configuration);
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}
due to this it always required to confirm the user Login email even we use Google Authentication.In order to fix this what I have did was when I create new user using Google Authentication login I set user parameters including EmailConfirmation=true addition to User name & User Email.Then that bug was fixed. after that when I call below function 
var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
`  
public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            if (ModelState.IsValid)
            {
                // var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };   comment dulith
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email ,EmailConfirmed=true};
                var result = await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, SD.User);
                if (result.Succeeded)
                {
                    
                    result = await _userManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation("User created an account using {Name} provider.", info.LoginProvider);
                       // return LocalRedirect(returnUrl);
                        return LocalRedirect("/Customer/ProjectsApiKey/");
                    }
                }
If user Exists 
result.Succeeded is true
And also Thank you very much for previous answer.
