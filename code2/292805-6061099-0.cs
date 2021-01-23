    public class APIVersionRoutingConstraint : IRouteConstraint
    {
        private string _versionNumber;
        public APIVersionRoutingConstraint(string versionNumber)
        {
            _versionNumber = versionNumber;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string version = null;
            if (httpContext.Request.ContentType.Contains("application/json"))
            {
                string body = new StreamReader(httpContext.Request.InputStream).ReadToEnd();
                httpContext.Request.InputStream.Position = 0;
                var vals = new JavaScriptSerializer().DeserializeObject(body) as Dictionary<string, object>;
                if (vals.ContainsKey("version"))
                    version = vals["version"].ToString();
            }
            // Must have version to pass constraint
            return !string.IsNullOrEmpty(version) && version == _versionNumber;
        }
    }
