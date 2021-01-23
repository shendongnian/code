    class UrlFactory : IUrlFactory
    {
        public IUrlWrapper Create()
        {
            var context = new HttpContextWrapper(HttpContext.Current);
            var routeData = RouteTable.Routes.GetRouteData(context);
            return new UrlWrapper(new UrlHelper(new RequestContext(context, routeData)));
        }
    }
