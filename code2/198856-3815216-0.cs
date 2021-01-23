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
    public class RazorViewEngineRender {
        internal static Dictionary<string, string> strings { get; set; }
        string guid;
        static RazorViewEngineRender() {
            strings = new Dictionary<string, string>();
        }
        public RazorViewEngineRender(string Template) {
            guid = Guid.NewGuid().ToString() + ".cshtml";
            strings.Add(guid, Template);
        }
        public string Render(object ViewModel) {
            //Register model type
            if (ViewModel == null) {
                strings[guid] = "@inherits System.Web.Mvc.WebViewPage\r\n" + strings[guid];
            } else {
                strings[guid] = "@inherits System.Web.Mvc.WebViewPage<dynamic>\r\n" + strings[guid];
            }
            CshtmlView view = new CshtmlView("/stringviews/" + guid);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.IO.TextWriter tw = new System.IO.StringWriter(sb);
            ControllerContext controller = new ControllerContext();
            ViewDataDictionary ViewData = new ViewDataDictionary();
            ViewData.Model = ViewModel;
            view.Render(new ViewContext(controller, view, ViewData, new TempDataDictionary(), tw), tw);
            //view.ExecutePageHierarchy();
            strings.Remove(guid);
            return sb.ToString();
        }
    }
