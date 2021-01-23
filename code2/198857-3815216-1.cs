    public class StringPathProvider : VirtualPathProvider {
        public StringPathProvider()
            : base() {
        }
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart) {
            return null;
        }
        public override bool FileExists(string virtualPath) {
            if (virtualPath.StartsWith("/stringviews") || virtualPath.StartsWith("~/stringviews"))
                return true;
            return base.FileExists(virtualPath);
        }
        public override VirtualFile GetFile(string virtualPath) {
            if (virtualPath.StartsWith("/stringviews") || virtualPath.StartsWith("~/stringviews"))
                return new StringVirtualFile(virtualPath);
            return base.GetFile(virtualPath);
        }
        public class StringVirtualFile : System.Web.Hosting.VirtualFile {
            string path;
            public StringVirtualFile(string path)
                : base(path) {
                //deal with this later
                    this.path = path;
            }
            public override System.IO.Stream Open() {
                return new System.IO.MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(RazorViewEngineRender.strings[System.IO.Path.GetFileName(path)]));
            }
        }
    }
