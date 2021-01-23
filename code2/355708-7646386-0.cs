    public abstract class Controller : ControllerBase, IActionFilter,
        IAuthorizationFilter, IDisposable, IExceptionFilter, IResultFilter
    {
        ...
        protected internal PartialViewResult PartialView()
        {
            ...
        }
        protected internal PartialViewResult PartialView(object model)
        {
            ...
        }
        protected internal PartialViewResult PartialView(string viewName)
        {
            ...
        }
        ...
    }
