    var request = new Mock<HttpRequestBase>(MockBehavior.Strict);
			var moqRequestContext = new Mock<RequestContext>(MockBehavior.Strict);
			request.SetupGet<RequestContext>(r => r.RequestContext).Returns(moqRequestContext.Object);
			var routeData = new RouteData();
			routeData.Values.Add("key1", "value1");
			moqRequestContext.Setup(r => r.RouteData).Returns(routeData);
			request.SetupGet(x => x.ApplicationPath).Returns(PathProvider.GetAbsolutePath(""));
    public interface IPathProvider
    {
        string GetAbsolutePath(string path);
    }
    public class PathProvider : IPathProvider
    {
         private readonly HttpServerUtilityBase _server;
         public PathProvider(HttpServerUtilityBase server)
         {
            _server = server;
         }
        public string GetAbsolutePath(string path)
        {
            return _server.MapPath(path);
        }
    }
