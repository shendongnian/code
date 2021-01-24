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
    [TestActionFilter] // this will be for EVERY inheriting api controller 
    public class BaseApiController : ApiController
    {
    }
    [TestActionFilter] // this will be for EVERY api method
    public class PersonController: BaseApiController
    {
        [HttpGet]
        [TestActionFilter] // this will be for just this one method
        public HttpResponseMessage GetAll()
        {
            //normal api stuff
        }
    }
