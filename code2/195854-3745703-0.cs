    /// <summary>
    /// Handles client side caching by automatically refreshing content when switching logged in identity
    /// </summary>
    public class ClientCacheByIdentityAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Sets the cache duraction in minutes
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// Check for incoming conditional requests
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction || filterContext.HttpContext.Request.RequestType!="GET" || filterContext.Result!=null)
            {
                return;
            }
            string modifiedSinceString = filterContext.HttpContext.Request.Headers["If-Modified-Since"];
            string noneMatchString = filterContext.HttpContext.Request.Headers["If-None-Match"];
            if (String.IsNullOrEmpty(modifiedSinceString) || String.IsNullOrEmpty(noneMatchString))
            {
                return;
            }
            DateTime modifiedSince;
            if (!DateTime.TryParse(modifiedSinceString, out modifiedSince))
            {
                return;
            }
            if (modifiedSince.AddMinutes(Duration) < DateTime.Now)
            {
                return;
            }
            string etag = CreateETag(filterContext.HttpContext);
            if (etag == noneMatchString)
            {
                filterContext.HttpContext.Response.StatusCode = 304;
                filterContext.Result = new EmptyResult();
            }
        }
        /// <summary>
        /// Handles setting the caching attributes required for conditional gets
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request.RequestType == "GET" && filterContext.HttpContext.Response.StatusCode == 200 && !filterContext.IsChildAction && !filterContext.HttpContext.Response.IsRequestBeingRedirected)
            {
                filterContext.HttpContext.Response.AddHeader("Last-Modified", DateTime.Now.ToString("r"));
                filterContext.HttpContext.Response.AddHeader("ETag", CreateETag(filterContext.HttpContext));
            }
        }
        /// <summary>
        /// Construct the ETag
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private static string CreateETag(HttpContextBase context)
        {
            return "\"" + CalculateMD5Hash(context.Request.Url.PathAndQuery + "$" + context.User.Identity.Name) + "\"";
        }
        /// <summary>
        /// Helper to make an MD5 hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
