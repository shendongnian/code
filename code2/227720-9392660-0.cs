    /* Register in routing */
    routes.Add("MyImageHandler",
               new Route("my-custom-url/{folder}/{filename}", 
               new ImageRouteHandler())
    );
    /* Your route handler */
    public class ImageRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string filename = requestContext.RouteData.Values["filename"] as string;
            string folder = requestContext.RouteData.Values["folder"] as string;
            string width = requestContext.HttpContext.Request.Params["w"] as string;
            string height = requestContext.HttpContext.Request.Params["h"] as string;
            // Look up the file and handle and return, etc...
        }
    }
