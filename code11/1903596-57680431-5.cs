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
