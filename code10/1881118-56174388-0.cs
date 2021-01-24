public class CompressAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var encodingsAccepted = filterContext.HttpContext.Request.Headers["Accept-Encoding"];
        if (string.IsNullOrEmpty(encodingsAccepted)) return;
        encodingsAccepted = encodingsAccepted.ToLowerInvariant();
        var response = filterContext.HttpContext.Response;
        if (encodingsAccepted.Contains("deflate"))
        {
            response.AppendHeader("Content-encoding", "deflate");
            response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
        }
        else if (encodingsAccepted.Contains("gzip"))
        {
            response.AppendHeader("Content-encoding", "gzip");
            response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
        }
    }
}
[Compress]
[HttpGet]
public ActionResult GetFile()
{...}
  [1]: https://weblog.west-wind.com/posts/2012/apr/28/gzipdeflate-compression-in-aspnet-mvc
