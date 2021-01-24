return Json(new
                    {
                        view = RenderRazorViewToString(ControllerContext, "ProductDataTable", model),
                        IsCostUpdated = model.IsCostUpdated
                    });
// Render Razor view as string to populate dom
public static string RenderRazorViewToString(ControllerContext controllerContext, string viewName, object model)
        {
            controllerContext.Controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var ViewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var ViewContext = new ViewContext(controllerContext, ViewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
                ViewResult.View.Render(ViewContext, sw);
                ViewResult.ViewEngine.ReleaseView(controllerContext, ViewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
// Razor View - Ajax call Success
success: function (data) {
                    $('body').find('.productTable').html(data.view);
                    var isSuccess = data.IsCostUpdated;
                }
