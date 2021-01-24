    class ProductsListController : ApiController
    {
        [Route("/products")]
        IActionResult GetAll( /* optional querystring params */ )
        [Route("/products/categories/{categoryName}")]
        IActionResult GetInCategory( String categoryName, /* optional querystring params */ )
    }
    class ProductController : ApiController
    {
        [Route("/products/{productId}")]
        IActionResult Get( Int32 productId )
        [HttpPost]
        [Route("/products/{productId}")]
        IActionResult Post( Int32 productId )
    }
