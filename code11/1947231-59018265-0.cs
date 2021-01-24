    public class ProductsApiController : Controller
    {
       [HttpGet("/products/{id}", Name = "Products_List")]
       public IActionResult GetProduct(int id) { ... }
    }
