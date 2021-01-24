    [Authorize(Policy = "AdminAccess")]
    public class AdministratorController : Controller
    {
      public IActionResult Index()
      {
        return View();
      }
    }
