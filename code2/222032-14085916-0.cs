    public static string RenderViewToString(Controller controller, string viewName, object model)
        {
            var oldController = controller.RouteData.Values["controller"].ToString();
            if (controller.GetType() != typeof(EmailController))
                controller.RouteData.Values["controller"] = "Email";
            var oldModel = controller.ViewData.Model;
            controller.ViewData.Model = model;
            try
            {
                using (var sw = new StringWriter())
                {
                    var viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName,
                                                                               null);
                    var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
                    //Cleanup
                    controller.ViewData.Model = oldModel;
                    controller.RouteData.Values["controller"] = oldController;
                    return sw.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                throw ex;
            }
        }
