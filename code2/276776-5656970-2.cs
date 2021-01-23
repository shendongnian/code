    public class GzipFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            var context = filterContext.HttpContext;
            if (!filterContext.ActionDescriptor.IsDefined(typeof(NoGzipAttribute), true))
            {
                string acceptEncoding = context.Request.Headers["Accept-Encoding"].ToLower();;
                if (acceptEncoding.Contains("deflate") || acceptEncoding == "*")
                {
                    context.Response.Filter = new DeflateStream(context.Response.Filter, CompressionMode.Compress);
                    context.Response.AppendHeader("Content-Encoding", "deflate");
                } 
                else if (acceptEncoding.Contains("gzip"))
                {
                    context.Response.Filter = new GZipStream(context.Response.Filter, CompressionMode.Compress);
                    context.Response.AppendHeader("Content-Encoding", "gzip");
                }                       
            }
        }
    }
