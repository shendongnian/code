    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString RenderPartialViewToString(
            this HtmlHelper html, 
            ControllerContext controllerContext, 
            ViewDataDictionary viewData,
            TempDataDictionary tempData,
            string viewName, 
            object model)
        {
            viewData.Model = model;
            string result = String.Empty;
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                ViewContext viewContext = new ViewContext(controllerContext, viewResult.View, viewData, tempData, sw);
                viewResult.View.Render(viewContext, sw);
                result = sw.GetStringBuilder().ToString();
            }
            return MvcHtmlString.Create(result);
        }
    }
