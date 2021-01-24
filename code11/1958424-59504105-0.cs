[Authorize]
public abstract class MyBaseController : Controller //use Controller for mvc controller or ControllerBase for api controller
{
//base controller methods and properties
}
Other controllers:
public class MyOtherController : MyBaseController 
{
//controller methods and properties
}
