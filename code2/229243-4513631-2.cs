    public class HttpStatusCodeResult : ActionResult
    {
        private readonly int code;
        public HttpStatusCodeResult(int code)
        {
            this.code = code;
        }
    
        public override void ExecuteResult(System.Web.Mvc.ControllerContext context)
        {
            context.HttpContext.Response.StatusCode = code;
        }
    }
