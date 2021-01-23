        public class CanonicalUrl : ActionFilterAttribute
        {
            private string _protocol;
            private string _host;
            public CanonicalUrl(string host, string protocol)
            {
                this._host = host;
                this._protocol = protocol;
            }
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                var canonical = GetCanonicalUrl(filterContext.RouteData,_host,_protocol);
                filterContext.Controller.ViewBag.CanonicalUrl = canonical.ToString();
            }
        }
    }
