    [Route("{application}/api/[controller]")
    public class BaseController: Controller
    {
        protected string CallingApp { get; set; }
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            CallingApp  = ctx.RouteData.Values["application"];
            base.OnActionExecuting(ctx);
        }
    }
