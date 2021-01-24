[Authorize]
public class HomeController : Controller 
then in endpoints you want to access anonymously
[AllowAnonymous] 
public ViewResult Index() 
{ 
      return View(); 
}  
or you could create a basecontroller class
[Authorize]
public class BaseController : Controller 
{
    ...
}
then inherit it
public class HomeController : BaseController
[or as listed in this documentation][1]
//sample code
services.AddMvc()
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizePage("/Contact");
        options.Conventions.AuthorizeFolder("/Private");
        options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
        options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
    })
  [1]: https://docs.microsoft.com/en-us/aspnet/core/security/authorization/razor-pages-authorization?view=aspnetcore-2.2
