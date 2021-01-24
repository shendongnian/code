    [MyRoute( "GET", "/products")]
    [MyRoute( "GET", "/products/categories/{categoryName}")]
    class ProductsListHandler : MyHandler
    {
        MyActionResult ProcessRequest( HttpContext httpContext )
    }
    [MyRoute( "GET", "/products/{productId}")]
    class ProductsGetHandler : MyHandler
    {
        MyActionResult ProcessRequest( HttpContext httpContext )
    }
    [MyRoute( "POST", "/products/{productId}")]
    class ProductsPostHandler : MyHandler
    {
        MyActionResult ProcessRequest( HttpContext httpContext )
    }
