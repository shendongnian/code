    public class AccountController : Controller
    {
    [HttpGet, Authorize(Roles = "Admin")]
    public ViewResult CreateUser()
    {
        return View();
    }
    [HttpPost, Authorize(Roles = "Admin")]
    public ViewResult CreateUser()
    {
        //... call service method to create user
    }
    [HttpPost, Authorize(Roles = "Admin")]
    public ViewResult AssignPageToUser(int userId, string controllerName, string ActionName)
    {
        //... insert record into table (UserPermissions) with attributes (userId, actionName, controllerName)
        }
    // other methods without decoration by authorize attribute
    }
