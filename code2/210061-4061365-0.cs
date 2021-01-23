    public class ImageHandlerRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var handler = new ImageHandler();
            handler.ProcessRequest(requestContext);
            return handler;
        }
    }
