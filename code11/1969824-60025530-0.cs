var user = UserManager.FindByName(model.UserName);
Then it means that the `SignInManager` is not initialized in your controller. 
var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
If you share your initialization code for the `SignInManager` we can help you more.
To get the manager in `Identity.Config.cs`
public static void RegisterAuth(IAppBuilder app)
{
   // Initialize the creation
   app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
}
And in startup.cs
[assembly: OwinStartup(typeof(Startup), "Configuration")]    
namespace MyNamespace
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AuthConfig.RegisterAuth(app);
        }
    }
}
