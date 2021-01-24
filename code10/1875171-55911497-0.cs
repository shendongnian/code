    [Route("[controller]")]
    public class ProductsController : Controller
    {
       [Route("")]     // Matches 'Products'
       [Route("Index")] // Matches 'Products/Index'
       public IActionResult Index()
    }
