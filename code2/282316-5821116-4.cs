    public class ServiceVirtualPathProvider : VirtualPathProvider
    {
        private bool IsServiceCall(string virtualPath)
        {
            virtualPath = VirtualPathUtility.ToAppRelative(virtualPath);
            return (virtualPath.ToLower().StartsWith("~/services/"));
        }
        public override VirtualFile GetFile(string virtualPath)
        {
            return IsServiceCall(virtualPath)
                       ? new ServiceFile(virtualPath)
                       : Previous.GetFile(virtualPath);
        }
        public override bool FileExists(string virtualPath)
        {
            if (IsServiceCall(virtualPath))
                return true;
            return Previous.FileExists(virtualPath);
        }
        public override System.Web.Caching.CacheDependency GetCacheDependency(string virtualPath, System.Collections.IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return IsServiceCall(virtualPath)
                       ? null
                       : Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }
