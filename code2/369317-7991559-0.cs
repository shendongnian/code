    public class MyCustomRoute : Route
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var url = httpContext.Request.ApplicationPath.TrimEnd('/');
            var relativeUri = httpContext.Request.Url.AbsolutePath.Remove(0, url.Length);
			
			// split url here
			// return null if the second path part is not a number
			// else invoke base.GetRouteData
            return null;
        }
    }
