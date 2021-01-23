        public static string RenderViewToString(ControllerContext controllerContext, string viewPath, ViewDataDictionary viewData, TempDataDictionary tempData)
        {
            ViewEngineResult result = ViewEngines.Engines.FindPartialView(controllerContext, viewPath);
            if (result == null || result.View == null)
                throw new Exception("No view found for the following path: " + viewPath);
            ViewContext viewContext = new ViewContext(controllerContext, result.View, viewData, tempData, new StringWriter());
            HtmlHelper helper = new HtmlHelper(viewContext, new ViewPage());
            return helper.Partial(viewPath, viewData).ToHtmlString();
        }
