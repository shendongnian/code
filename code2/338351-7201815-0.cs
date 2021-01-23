    public class HomeController : Controller
    {
      private IService _service;
      public HomeController(IService service)
      {
        _service = service;
      }
    // ..
    }
