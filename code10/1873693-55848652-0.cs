    public class TestActionFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Method.Method == "GET")
            {
                //do stuff for all get requests
            }
            base.OnActionExecuting(actionContext);
        }
    }
    [TestActionFilter]
    public class BaseApiController : ApiController
    {
    }
    public class PersonController: BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //normal api stuff
        }
    }
