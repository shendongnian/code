    public class AbsoluteUrlHelper
    {
        /// <summary>
        /// Creates an absolute "fully qualified" url from an action, and assumes the current controller.
        /// </summary>
        /// <returns></returns>
        public static string GetAbsoluteUrl(string action, object routeValues = null)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            var values = urlHelper.RequestContext.RouteData.Values;
            var controller = values["controller"].ToString();
            return GetAbsoluteUrl(action, controller, urlHelper, routeValues);
        }
        /// <summary>
        /// Creates an absolute "fully qualified" url from an action and controller.
        /// </summary>
        public static string GetAbsoluteUrl(string action, string controller, object routeValues = null)
        {
            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
            return GetAbsoluteUrl(action, controller, urlHelper, routeValues);
        }
        /// <summary>
        /// Creates an absolute "fully qualified" url from an action and controller.
        /// </summary>
        public static string GetAbsoluteUrl(string action, string controller, UrlHelper urlHelper, object routeValues = null)
        {
            var uri = urlHelper.Action(action, controller, routeValues, "http");
          
            return uri;
        }
    }
