csharp
[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    [HttpGet("{userId}/{userEmail}")]
    public JsonResult GetCustomer(string userId, string userEmail)
    {
        return new JsonResult(string.Format("userId: {0}, email: {1} ", userId, userEmail));
    }
}
So you can request api like this
    https://localhost:44371/api/customers/1
Another example
csharp
[Route("[controller]/[action]")]
public class ProductsController : Controller
{
    [HttpGet] // Matches '/Products/List'
    public IActionResult List() {
        // ...
    }
    [HttpGet("{id}")] // Matches '/Products/Edit/{id}'
    public IActionResult Edit(int id) {
        // ...
    }
}
