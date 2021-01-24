    [Area("MyArea")]
    [Authorize]
    public class FooController : Controller
    {
    
        [HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }
    
    }
