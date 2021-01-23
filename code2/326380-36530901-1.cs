    public abstract class BaseAppController : Controller
        {
            protected HttpVerbs? HttpVerb
            {
                get
                {
                    var httpMethodOverride = ControllerContext.HttpContext.Request.GetHttpMethodOverride();
                    return HttpVerbsHelper.GetVerb(httpMethodOverride);
                }
            }
    }
