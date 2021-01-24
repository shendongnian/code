c#
namespace TaskWebApp.Controllers
{
[Authorize] 
    public class SomethingElseController : Controller
    {
       public async Task<ActionResult> Index(){
           if(Session["foo"] == null){ //there is no session data
               await SignUpSignIn("/somethingelse") //This goes to the account controller and applies permissions on the session
           }
           else 
           {
               return View();
           }
        }
       private async Task SignUpSignIn(string redirectLink = "")
        {
            var controller = DependencyResolver.Current.GetService<AccountController>();
            controller.ControllerContext = new ControllerContext(Request.RequestContext, controller);
            await controller.SignUpSignIn(redirectLink);
        }
    }
}
