    [Route("[controller]")]
    public class CarsRegistrationController : Controller
    {
       [Route("")]     // Matches 'Products'
       [Route("Index")] // Matches 'Products/Index'
       public IActionResult Index()
    }
