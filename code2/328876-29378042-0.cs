    public class LogErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            int responseCode = new int();
            // Has the exception been handled.  Also, are custom errors enabled
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
                return;
            // Check if custom exception, if so get response code
            if (filterContext.Exception is CustomException)
                responseCode = (int)((CustomException)filterContext.Exception).Code;
            // Log exception
            string id = Logging.Write(LogType.Error, new
            {
                ResponseCode = responseCode,
                Exception = new
                {
                    Message = filterContext.Exception.Message,
                    Data = filterContext.Exception.Data,
                    Source = filterContext.Exception.Source,
                    StackTrace = filterContext.Exception.StackTrace,
                    InnerException = filterContext.Exception.InnerException != null ? new
                    {
                        Message = filterContext.Exception.InnerException.Message,
                        Data = filterContext.Exception.InnerException.Data,
                        Source = filterContext.Exception.InnerException.Source,
                        StackTrace = filterContext.Exception.InnerException.StackTrace
                    } : null
                },
                Context = filterContext.Controller != null ? new
                { 
                    RouteData = filterContext.Controller.ControllerContext.RouteData,
                    QueryString = filterContext.Controller.ControllerContext.HttpContext.Request.Url.Query,
                    FormParams = filterContext.Controller.ControllerContext.HttpContext.Request.Form != null ? string.Join(";#", filterContext.Controller.ControllerContext.HttpContext.Request.Form.AllKeys.Select(key => key + ":" + filterContext.Controller.ControllerContext.HttpContext.Request.Form[key])) : string.Empty,
                    Model = (filterContext.Controller is Controller) ? ((Controller)filterContext.Controller).ModelState : null,
                    ViewBag = filterContext.Controller.ViewBag,
                    ViewData = filterContext.Controller.ViewData
                } : null,
                ActionResult = filterContext.Result != null ? filterContext.Result : null,
                Referrer = filterContext.HttpContext.Request.UrlReferrer != null ? filterContext.HttpContext.Request.UrlReferrer : null
            }).Result;
            // Mark exception as handled and return
            filterContext.ExceptionHandled = true;
            // Test for Ajax call
            if (IsAjax(filterContext))
            {
                // Construct appropriate Json response
                filterContext.Result = new JsonResult()
                {
                    Data = new
                    {
                        code = responseCode,
                        id = id,
                        message = filterContext.Exception.Message
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                var result = new ViewResult();
                result.ViewName = "_CustomError";
                result.ViewBag.CorrelationId = id;
                filterContext.Result = result;
            }
        }
        /// <summary>
        /// Determine if the request is from an Ajax call
        /// </summary>
        /// <param name="filterContext">The request context</param>
        /// <returns>True or false for an Ajax call</returns>
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
