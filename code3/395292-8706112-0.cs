    public abstract class MyBaseController : Controller
    {
        public EmptyResult ExecutionError(string message)
        {
            Response.StatusCode = 550;
            Response.Write(message);
            return new EmptyResult();
        }
    }
