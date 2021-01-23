    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GetSelectedClass(
            this HtmlHelper<BaseViewModel> html, 
            string controllerName, 
            params string[] actionNames
        )
        {
            BaseViewModel model = html.ViewData.Model
            ...
        }
    }
