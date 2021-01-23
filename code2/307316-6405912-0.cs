        string RenderPartialViewToString(string viewName, object model, ControllerContext controllerContext);
    }
    public class ViewMailer : IViewMailer
    {
        #region IViewMailer Members
        public string RenderPartialViewToString(string viewName, object model, ControllerContext controllerContext)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controllerContext.RouteData.GetRequiredString("action");
            controllerContext.Controller.ViewData.Model = model;
            using (var stringWriter = new StringWriter())
            {
                ViewEngineResult viewEngineResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewEngineResult.View,
                                                  controllerContext.Controller.ViewData,
                                                  controllerContext.Controller.TempData, stringWriter);
                viewEngineResult.View.Render(viewContext, stringWriter);
                return stringWriter.GetStringBuilder().ToString();
            }
        }
        #endregion
    }
