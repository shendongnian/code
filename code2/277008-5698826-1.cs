    public class QueryStringRoute : RouteBase
    {
        private static string[] queryStringUrls = new string[]
        {
            @"~/Article/\d{1,6}/.*?page=\d{1,3}"
        };
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            string url = httpContext.Request.AppRelativeCurrentExecutionFilePath;
            foreach (string queryStringUrl in queryStringUrls)
            {
                Regex regex = new Regex(queryStringUrl);
                if (regex.IsMatch(url))
                {
                    long id = 0; /* Parse the value from regex match */
                    int page = 0; /* Parse the value from regex match */
                    string name = ""; /* Parse the value from regex match */
                    RouteData rd = new RouteData(this, new MvcRouteHandler());
                    rd.Values.Add("controller", "QueryStringUrl");
                    rd.Values.Add("action", "Redirect");
                    rd.Values.Add("id", id);
                    rd.Values.Add("page", page);
                    rd.Values.Add("name", name);
                    rd.Values.Add("controllerToRedirect", "Article");
                    rd.Values.Add("actionToRedirect", "View");
                    return rd;
                }
            }
            return null;
        }
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
