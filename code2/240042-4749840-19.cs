    public class RouteInfo
        {
            public RouteInfo(RouteData data)
            {
                RouteData = data;
            }
    
            public RouteInfo(Uri uri, string applicationPath)
            {
                RouteData = RouteTable.Routes.GetRouteData(new InternalHttpContext(uri, applicationPath));
            }
    
            public RouteData RouteData { get; private set; }
    
            private class InternalHttpContext : HttpContextBase
            {
                private readonly HttpRequestBase _request;
    
                public InternalHttpContext(Uri uri, string applicationPath) : base()
                {
                    _request = new InternalRequestContext(uri, applicationPath);
                }
    
                public override HttpRequestBase Request { get { return _request; } }
            }
    
            private class InternalRequestContext : HttpRequestBase
            {
                private readonly string _appRelativePath;
                private readonly string _pathInfo;
    
                public InternalRequestContext(Uri uri, string applicationPath) : base()
                {
                    _pathInfo = ""; //uri.Query; (this was causing problems, see comments - Stuart)
    
                    if (String.IsNullOrEmpty(applicationPath) || !uri.AbsolutePath.StartsWith(applicationPath, StringComparison.OrdinalIgnoreCase))
                        _appRelativePath = uri.AbsolutePath;
                    else
                        _appRelativePath = uri.AbsolutePath.Substring(applicationPath.Length);
                }
    
                public override string AppRelativeCurrentExecutionFilePath { get { return String.Concat("~", _appRelativePath); } }
                public override string PathInfo { get { return _pathInfo; } }
            }
        }
