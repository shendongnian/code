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
If user Exists 
result.Succeeded is true
And also Thank you very much for previous answer.
