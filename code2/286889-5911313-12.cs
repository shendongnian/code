    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class HandleErrorAttribute : FilterAttribute, IExceptionFilter
    {
    
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
    
            if (filterContext.ExceptionHandled)
            {
                return;
            }
    
            var exception = filterContext.Exception;
    
            // that need to be your current request object. In this case I use a custom one so I must fetch it from the items collection of the current request, where I had stored it before.
            var request = filterContext.HttpContext.Items[Request.RequestKey] as Request;
    
            if (request != null)
            {
                // overwrite ErrorResponse with a response object of your choice or write directly to the filterContext.HttpContext.Response
                var errorResponse = new ErrorResponse(request, exception); 
                errorResponse.Write(filterContext.HttpContext.Response);
                filterContext.ExceptionHandled = true;
            }
        }
    }
    // Or a just slightly modified version of the default ASP.Net MVC HandleError Attribute
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
        public class CustomHandleErrorAttribute : FilterAttribute, IExceptionFilter
        {
            // Fields
            private const string _defaultView = "Error";
            private string _master;
            private readonly object _typeId = new object();
            private string _view;
    
            // Methods
            public virtual void OnException(ExceptionContext filterContext)
            {
                if (filterContext == null)
                {
                    throw new ArgumentNullException("filterContext");
                }
                if (!filterContext.IsChildAction && (!filterContext.ExceptionHandled && filterContext.HttpContext.IsCustomErrorEnabled))
                {
                    Exception innerException = filterContext.Exception;
                    if ((new HttpException(null, innerException).GetHttpCode() == 500))
                    {
                        string controllerName = (string)filterContext.RouteData.Values["controller"];
                        string actionName = (string)filterContext.RouteData.Values["action"];
                        HandleErrorInfo model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
                        ViewResult result = new ViewResult();
                        result.ViewName = this.View;
                        result.MasterName = this.Master;
                        result.ViewData = new ViewDataDictionary<HandleErrorInfo>(model);
                        result.TempData = filterContext.Controller.TempData;
                        filterContext.Result = result;
                        filterContext.ExceptionHandled = true;
                        filterContext.HttpContext.Response.Clear();
                        filterContext.HttpContext.Response.StatusCode = 500;
                        filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                    }
                }
            }
    
            public string Master
            {
                get
                {
                    return (this._master ?? string.Empty);
                }
                set
                {
                    this._master = value;
                }
            }
    
            public override object TypeId
            {
                get
                {
                    return this._typeId;
                }
            }
    
            public string View
            {
                get
                {
                    if (string.IsNullOrEmpty(this._view))
                    {
                        return "Error";
                    }
                    return this._view;
                }
                set
                {
                    this._view = value;
                }
            }
        }
