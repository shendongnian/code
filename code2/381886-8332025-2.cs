    internal class ViewDataContainer : IViewDataContainer
    {
        public ViewDataContainer(ViewDataDictionary viewData)
        {
            ViewData = viewData;
        }
        public ViewDataDictionary ViewData { get; set; }
    }
    public static class ControllerHtml
    {
        private static HtmlHelper htmlHelper;
        public static HtmlHelper Html(Controller controller)
        {
            if (htmlHelper == null)
            {
                var vdd = new ViewDataDictionary();
                var tdd = new TempDataDictionary();
                var controllerContext = controller.ControllerContext;
                var view = new RazorView(controllerContext, "/", "/", false, null);
                htmlHelper = new HtmlHelper(new ViewContext(controllerContext, view, vdd, tdd, new StringWriter()),
                     new ViewDataContainer(vdd), RouteTable.Routes);
            }
            return htmlHelper;
        }
    }
