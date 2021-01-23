    public class HttpStatusCodeResultWithJson : JsonResult
    {
        private int _statusCode;
        private string _description;
        public HttpStatusCodeResultWithJson(int statusCode, string description = null)
        {
            _statusCode = statusCode;
            _description = description;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var httpContext = context.HttpContext;
            var response = httpContext.Response;
            response.StatusCode = _statusCode;
            response.StatusDescription = _description;
            base.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.ExecuteResult(context);
        }
    }
