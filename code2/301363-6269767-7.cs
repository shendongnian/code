    public class MyController:Controller
    {
    [Authorize(Roles = "Manager")]
    [Authorize(Roles = "Admin")]
    public ActionResult Action1()
    {
    //...
    }
    }
