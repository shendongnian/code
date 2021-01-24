c#
[Authorize(Roles = "Administrator")]
public class AdministrationController : Controller
{
}
or
c#
[Authorize(Roles = "Administrator, PowerUser")]
public class ControlPanelController : Controller
{
    public ActionResult SetTime()
    {
    }
    [Authorize(Roles = "Administrator")]
    public ActionResult ShutDown()
    {
    }
}
Then you could create a Role for your M2M application and allow this application only specific methods and the users that use your frontend can have other roles. As you can see in the second example, you can set Authoriziation Roles on the Controller itself and then later on your methods bring the scope down.
