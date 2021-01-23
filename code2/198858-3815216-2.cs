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
        
        public string Render() {
            return Render(null);
        }
        public string Render(object ViewModel) {
            //Register model type
            if (ViewModel == null) {
                strings[guid] = "@inherits System.Web.Mvc.WebViewPage\r\n" + strings[guid];
            } else {
                strings[guid] = "@inherits System.Web.Mvc.WebViewPage<" + ViewModel.GetType().FullName + ">\r\n" + strings[guid];
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
