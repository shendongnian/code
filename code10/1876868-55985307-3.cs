    public class HomeController : Controller {
    
      private readonly IFanApiClientFactory _fanApiClientFactory;
    
      public HomeController(IFanApiClientFactory fanApiClientFactory) {
        _fanApiClientFactory = fanApiClientFactory;
      }
    
      public async Task<IActionResult> Index() {
    
        var starWarsApiClient = _fanApiClientFactory.CreateStarWarsApiClient();
        var starTrekApiClient = _fanApiClientFactory.CreateStarTrekApiClient();
    
        var person1 = await starTrekApiClient.GetMostImportantPerson();
        var person2 = await starWarsApiClient.GetMostImportantPerson();
    
        return View();
      }
    }
