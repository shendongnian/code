    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
       [HttpPost("Details")]     
        public async Task<IActionResult> GetDetails(string value = null)
        {
            ...
        }
    }
