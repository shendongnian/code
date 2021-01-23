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
