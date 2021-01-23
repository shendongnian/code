    public class MyCustomAttribute : ActionFilterAttribute {
        public override void OnActionExecuted(ActionExecutedContext filterContext) {
            var response = filterContext.HttpContext.Response;
            if (response.ContentType == "text/html") {
                response.Filter = new HelperClass(response.Filter);
            }
        }
    }
