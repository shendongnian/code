    public class ToggleHttpHttpsAttribute : FilterAttribute, IAuthorizationFilter
    {
        //supported uri scheme values
        public enum UriScheme
        {
            Http,
            Https
        }
        public ToggleHttpHttpsAttribute(
            UriScheme uriScheme = UriScheme.Http)
        {
            TargetUriScheme = uriScheme;
        #if DEBUG
            //set DEBUG ports
            HttpPort = 55892;
            HttpsPort = 44301;
        #endif
        }
        private UriScheme TargetUriScheme { get; set; }
        public int? HttpPort { get; set; }
        public int? HttpsPort { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if(filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
                       
            bool isHttps = filterContext.HttpContext.Request.IsSecureConnection;
            if ((isHttps && TargetUriScheme == UriScheme.Http) || (!isHttps && TargetUriScheme == UriScheme.Https))
            {
                ToggleUriScheme(filterContext);
            }
        }
        private void ToggleUriScheme(AuthorizationContext filterContext)
        {
            //only allow toggle if GET request
            if (!string.Equals(filterContext.HttpContext.Request.HttpMethod, "GET",   StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("ToggleHttpHttpsAttribute can only be used on GET requests.");
            }
            filterContext.Result = GetRedirectResult(filterContext);
        }
        private RedirectResult GetRedirectResult(AuthorizationContext filterContext)
        {
            string prefix = TargetUriScheme == UriScheme.Http
                ? "http://"
                : "https://";
            int? port = TargetUriScheme == UriScheme.Http
                ? HttpPort
                : HttpsPort;
            string url = string.Format(
                "{0}{1}{2}{3}",
                prefix,
                filterContext.HttpContext.Request.Url.Host,
                port == null ? "" : string.Format(":{0}", port),
                filterContext.HttpContext.Request.RawUrl);
            return new RedirectResult(url);
        }
    }
